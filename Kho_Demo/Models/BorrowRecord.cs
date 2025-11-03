using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Models
{
    public class BorrowRecord
    {
        public int ID { get; set; } = 0;
        public int ProductRTCID { get; set; } = 0;
        public DateTime DateBorrow { get; set; } = DateTime.Now;
        public DateTime DateReturnExpected { get; set; } = DateTime.Now;
        public int PeopleID { get; set; } = 0;
        public string Project { get; set; } = string.Empty;
        public DateTime DateReturn { get; set; } = DateTime.Now;
        public string Note { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
        public int NumberBorrow { get; set; } = 0;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool AdminConfirm { get; set; } = false;
        public int BillExportTechnicalID { get; set; } = 0;
        public int ProductRTCQRCodeID { get; set; } = 0;
        public int WarehouseID { get; set; } = 0;
        public string ProductRTCQRCode { get; set; } = string.Empty;
        public bool IsDelete { get; set; } = false;
        public int ProductLocationID { get; set; } = 0;
        public int StatusPerson { get; set; } = 0;
    }

}
