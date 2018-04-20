using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingMachine.Model
{
    public class Truck
    {
        public string VoucherID { set; get; }
        public string CheckInTime { set; get; }
        public string CheckOutTime { set; get; }
        public string VehicleNO { set; get; }
        public string CompanyName { set; get; }
        public string ProductName { set; get; }
        public decimal FirstWeight { set; get; }
        public decimal SecondWeight { set; get; }
        public string Security { set; get; }
        public string Driver { set; get; }
        public string Note { set; get; }
        public string Status { set; get; }
    }
}
