using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleWcfLib
{
    [ServiceContract]
    public interface ISportService
    {
        [OperationContract]
        void RegisterUser(Customer customer);
        [OperationContract]
        void BookCourt(Slot slot);
        [OperationContract]
        List<Slot> GetAllBookedSlots();
        [OperationContract]
        List<Customer> GetAllCustomers();
    }

    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long ContactNo { get; set; }
        [DataMember]
        public double Fees { get; set; }
        [DataMember]
        public int CstID { get; set; }
    }

    [DataContract]
    public class Slot
    {
        [DataMember]
        public int CustomerID { get; set; }
        public int CourtNo { get; set; }
        [DataMember] public int SlotUnits { get; set; } = 1;
        [DataMember] public DateTime StartTime { get; set; }
        [DataMember]
        public int TotalAmount
        {
            get
            {
                return 200 * SlotUnits;
            }
            set
            {

            }
        }

        public DateTime EndTime => StartTime.AddHours(SlotUnits * 2);
    }
}
/*
 * CstNo int Primary key IDENTITY(1,1),
 * CstID int NOT NULL,
 * CstName varchar(50) NOT NULL, 
 * CstPhone bigint NOT NULL,
 * SlotDate DateTime, 
 * SlotEndDate DateTime, 
 * Fees money NOT NULL
 * CourtNo int
 */
