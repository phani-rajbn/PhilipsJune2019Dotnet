using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;//For UR Databases...
using System.Data;

namespace SampleWcfLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SportService : ISportService
    {
        const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True";

        const string strReg = "Insert into SportTable Values(@name, @phone)";
        //const string strReg = "Insert into SportTable Values(@id, @name, @phone)";

        public void RegisterUser(Customer customer)
        {
//            customer.
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(strReg, con);
            //cmd.Parameters.AddWithValue("@id", customer.CstID);
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@phone", customer.ContactNo);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//For inserting data....
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public void BookCourt(Slot slot)
        {
            SqlConnection con = new SqlConnection(strCon);
            var query = string.Format("insert into SportSlotTable values('{0}',{1},{2},{3})", slot.StartTime.ToString(), slot.SlotUnits, slot.TotalAmount, slot.CustomerID);
            var cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public List<Slot> GetAllBookedSlots()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand("SELECT SportTable.CstID, CstName, CstPhone, SUM(SportSlotTable.Fees) AS Fees FROM SportSlotTable INNER JOIN SportTable ON SportSlotTable.CustomerID = SportTable.CstID GROUP BY CstName, CstPhone, SportTable.CstID", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    Customer cst = new Customer
                    {
                        ContactNo = Convert.ToInt64(reader[2]),
                        Name = reader[1].ToString(),
                        CstID = Convert.ToInt32(reader[0]),
                        Fees = Convert.ToDouble(reader[3])
                    };
                    customers.Add(cst);
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        
    }
}
