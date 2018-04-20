using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeightingMachine.Helper;
using WeightingMachine.Model;

namespace WeightingMachine.Contact
{
    public interface ITruckDAL
    {
        OperationResult CreateTruck(Truck truck);
        Truck FindTruckByVehicleNO(string vehicleNO);
        Truck FindTruck(string voucherid);
        OperationResult UpdateTruck(Truck truck);
        OperationResult Remove(string voucherid);
       // OperationResult RemoveAll();
        XDocument ReadFile(string filename);
        bool iCanSave(string vehicleNO);
        void Save();
    }
}
