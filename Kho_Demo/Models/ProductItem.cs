using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Models
{
    public class ProductItem
    {
        public int ID { get; set; }
        public int Status { get; set; }
        public int ProductRTCID { get; set; }
        public string ProductQRCode { get; set; }
        public string Serial { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int WarehouseID { get; set; }
        public int ModulaLocationDetailID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCodeRTC { get; set; }
        public string AddressBox { get; set; }
        public string Note { get; set; }
        public string StatusText { get; set; }
        public string ModulaLocationName { get; set; }
        public bool IsSelected { get; set; }
    }

}
