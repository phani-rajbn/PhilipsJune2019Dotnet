using System;
using System.Collections.Generic;
using System.Data;//For DataSet(Data Structure)....
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;//For SQL Server related classes....

/// <summary>
/// Summary description for EmpDataService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EmpDataService : System.Web.Services.WebService
{

    [WebMethod]//This makes the method accessible thro Web....
    public List<string> GetAllEmployees()
    {
        return new List<string>
        {
            "Phaniraj",
            "Vinod Kumar",
            "Bnilnath",
            "Venugopal Shastri",
            "Banu Prakash",
            "Sukumar"
        };
    }
    [WebMethod]
    public DataSet GetAllRecords()
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True");

        SqlCommand cmd = new SqlCommand("SELECT * FROM EMPTABLE", con);
        try
        {
            con.Open();
            var reader = cmd.ExecuteReader();
            DataSet ds = new DataSet();
            DataTable table = new DataTable("EmpRecords");
            table.Load(reader);
            ds.Tables.Add(table);
            return ds;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }
    }

}
