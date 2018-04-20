using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightingMachine.Helper;
using WeightingMachine.Model;

namespace WeightingMachine.Contact
{
    public interface ITruckInOut
    {

        OperationResult CheckIn(string voucherid);
        OperationResult CheckOut(string voucherid);
        OperationResult FirstWeight(string voucherid, decimal weight);
        OperationResult SecondWeight(string voucherid, decimal weight);
        OperationResult Print(string voucherid);

    }
}
