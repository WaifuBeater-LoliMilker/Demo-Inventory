using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Models
{
    public class QRInfo
    {
        public int ID { get; set; }
        public int ProductRTCID { get; set; }
        public string ProductQRCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductCodeRTC { get; set; }
        public string Note { get; set; }
        public int UnitCountID { get; set; }
        public string Maker { get; set; }
        public int Soluong { get; set; }
        public bool Color { get; set; }
        public string AddressBox { get; set; }
    }
}
