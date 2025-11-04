using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Models
{
    public class BorrowRecordDTO
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<BorrowRecord> data { get; set; }
        public string error { get; set; }
    }
}
