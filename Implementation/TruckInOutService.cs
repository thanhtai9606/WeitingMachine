using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightingMachine.Contact;
using WeightingMachine.Helper;
using WeightingMachine.Model;

namespace WeightingMachine.Implementation
{
    public class TruckInOutService: ITruckInOut
    {
        ITruckDAL _truckDal = new TruckDALService();
         
        OperationResult operationResut = new OperationResult();
        Truck _currentTruck = new Truck();
        public OperationResult CheckIn(string voucherid)
        {
            _currentTruck = _truckDal.FindTruck(voucherid);

            _currentTruck.CheckInTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _currentTruck.Status = "I";
            
            operationResut = _truckDal.UpdateTruck(_currentTruck);
            return operationResut;
            
        }
        public OperationResult CheckOut(string voucherid)
        {                     
            _currentTruck = _truckDal.FindTruck(voucherid);
            _currentTruck.CheckOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _currentTruck.Status = "O";
            operationResut = _truckDal.UpdateTruck(_currentTruck);
            return operationResut;
        }
        public OperationResult FirstWeight(string voucherid, decimal weight)
        {
            _currentTruck = _truckDal.FindTruck(voucherid);
            _currentTruck.FirstWeight = weight;
            _currentTruck.Status = "D";
            operationResut = _truckDal.UpdateTruck(_currentTruck);
            return operationResut;
        }
        public OperationResult SecondWeight(string voucherid, decimal weight)
        {
            _currentTruck = _truckDal.FindTruck(voucherid);
            _currentTruck.SecondWeight = weight;
            _currentTruck.Status = "E";
            operationResut = _truckDal.UpdateTruck(_currentTruck);
            return operationResut;
        }
        public OperationResult Print(string vehicleNO)
        {
            throw new NotImplementedException();
        }
       
       
    }
}
