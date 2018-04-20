using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeightingMachine.Contact;
using WeightingMachine.Helper;
using WeightingMachine.Implementation;
using WeightingMachine.Model;
using System.Configuration;

namespace WeightingMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
            this.Load += new EventHandler(EGATE_Load);
            RegisterCommand();
        }
        OperationResult operationResult = new OperationResult();

        ITruckDAL _truckDAL = new TruckDALService();
        ITruckInOut _truckInOut = new TruckInOutService();
        Truck _truck = new Truck();          
       
        public System.IO.Ports.SerialPort PORT//Serial Weighing
        {
            get
            {
                return serialPort;
            }
            set
            {
                serialPort = value;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (serialPort != null)
                serialPort.Dispose();
            base.OnClosed(e);
        }      
     
        private void Reset()
        {            
            txtVehicleNO.Text = string.Empty;
            txtFirstWeight.Text = string.Empty;
            txtSecondWeight.Text = string.Empty; 
           // txtNote.Text = string.Empty;
        }
        //Create for New Truck
        private void CreateTruck()
        {
            //Create new TruckInfo
            _truck = new Truck();
            _truck.VoucherID = Guid.NewGuid().ToString();
            _truck.VehicleNO = txtVehicleNO.Text;
           // _truck.Note = txtNote.Text;
            _truck.FirstWeight = 0;
            _truck.SecondWeight = 0;
            _truck.Status = "C";
            operationResult = _truckDAL.CreateTruck(_truck);
            if (operationResult.Success)
            {
                _txtMsg.Text = "Đã tạo xe mới " + _truck.VehicleNO;
            }
            else { _txtMsg.Text = "Lỗi tạo xe " + _truck.VehicleNO + " " + operationResult.Message; }
        }
        //Check for TruckIn
        public void CheckIn4Truck()
        {
            operationResult = _truckInOut.CheckIn(_truck.VoucherID);       
            if (operationResult.Success)
            {
                _txtMsg.Text = "Xe đã vào.";
            }
            else
            {
                _txtMsg.Text = "Lỗi xe vào " + operationResult.Message;
            }

            BtnShow4Truck();
        }
        //Check for TruckOut
        public void CheckOut4Truck()
        {
            operationResult = _truckInOut.CheckOut(_truck.VoucherID);
            if (operationResult.Success)
            {
                _txtMsg.Text = "Xe đã ra.";
            }
            else
            {
                _txtMsg.Text = "Lỗi xe ra. " + operationResult.Message;
            }
            BtnShow4Truck();
        }   
        string MainMsg
        {
            set
            {
                _txtMsg.Text = value;
                _txtMsg.Refresh();
            }
        }
        string dataWeight = "";
        DataPackage dataPackage = new DataPackage { Weight = 0m, LastActive = DateTime.Now };
        //read Comvalue and get Weight in Time
        private void timer4ComMonitor_Tick(object sender, EventArgs e)
        {
            string ledComName = PORT.PortName.ToUpper().Trim().Replace("COM", "").PadLeft(3, '0');

            ledStationID.Text = ledComName;
           
            if ((dataPackage.LastValidated - DateTime.Now).Duration() > new TimeSpan(0, 0, 2))
            {
                led1.ForeColor = Color.Red;
              
            }
            else
            {
                if ((dataPackage.LastChanged - DateTime.Now).Duration() < new TimeSpan(0, 0, 2))
                {
                    led1.ForeColor = Color.Yellow;
                   
                }
                else
                {
                    led1.ForeColor = Color.Blue;
                    
                }

                dataWeight = dataPackage.Weight.ToString().PadLeft(8, ' ');
                led1.Text = dataWeight;

            }

            if ((dataPackage.LastActive - DateTime.Now).Duration() > new TimeSpan(0, 0, 5))
            {
                lc1.Visible = true;
              
            }
            else
            {
                lc1.Visible = false;
              
            }
        }
        private void Print(string VoucherID,  bool isPaperPrint)
        {
            Print doc = new Print(VoucherID);
            doc.Setting = "V;800;1000;False;-70;-5;80;90";
            doc.PrintBill(isPaperPrint);
            operationResult =_truckDAL.Remove(VoucherID);
            BtnShow4Truck();
            Reset();
        }
        public string Setting4Print { get; set; }
        private void RegisterCommand()
        {
            btnSearchTruck.Click += new EventHandler(btnSearchTruck_Click);
            btnBackTruck.Click += new EventHandler(btnBackTruck_Click);
            btnWeightTruck.Click += new EventHandler(btnWeightTruck_Click);
            btnInTruck.Click += new EventHandler(btnInTruck_Click);
            btnOutTruck.Click += new EventHandler(btnOutTruck_Click);
            btnPrintTruck.Click += new EventHandler(btnPrintTruck_Click);
        }
        private void btnPrintTruck_Click(object sender, EventArgs e)
        {
            Print(_truck.VoucherID, true);
            
        }
        private void SearchTruck()
        {
           
            TruckQueryPlan();
           
        }
        private void TruckQueryPlan()
        {           
            
            //GetTrucks          
            if (txtVehicleNO.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số xe.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
 
            }
            else
            {
               // _truck = new Truck();
                _truck = _truckDAL.FindTruckByVehicleNO(txtVehicleNO.Text);
                if (_truck == null)
                {
                    DialogResult dialogResult = MessageBox.Show("Chưa có xe này.\nBạn có muốn tạo mới?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                    if (dialogResult == DialogResult.Yes)
                    {
                        CreateTruck();
                    }

                    BtnShow4Truck();                                                    
                }
                else
                {
                    txtVehicleNO.Text = _truck.VehicleNO.ToString();
                    txtFirstWeight.Text = _truck.FirstWeight == 0 ? string.Empty : _truck.FirstWeight.ToString();
                    txtSecondWeight.Text = _truck.SecondWeight == 0 ? string.Empty : _truck.SecondWeight.ToString();
                    //txtNote.Text = _truck.Note.ToString();

                    switch (_truck.Status)
                    {
                         case "C":
                            BtnShow4TruckIn();
                            break;
                         case "I":
                             BtnShow4FirstWeight();
                            break;
                         case "D":
                             BtnShow4SecondWeight();
                            break;
                         case "E":
                            BtnShow4TruckOut();
                            //BtnShow4Print();
                            break;
                         case "O":
                             BtnShow4Print();;
                           // BtnShow4TruckOut();
                            break;
                    }                   
                   
                   // BtnShow4Truck();
                    btnWeightTruck.Enabled = true;
                    MainMsg = "*_*";
                    
                }
                //BtnShow4Truck();
            }
           
            
        }
    

        private void Weighting(decimal weightTruck)
        {
           
            weight = 0m;
            if (weightTruck < 40m)
            {
                MessageBox.Show("Nhỏ hơn 40KG", "Information");
                return;
            }

            weight = weightTruck;
           var _currentTruck = _truckDAL.FindTruck(_truck.VoucherID);
            //check for In or Out to get Weight
           if (_currentTruck.Status == "I")
            {
                _currentTruck.FirstWeight = weight;
                _currentTruck.CheckInTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                operationResult = _truckInOut.FirstWeight(_currentTruck.VoucherID, weight);
                if (operationResult.Success)
                {                   
                    _txtMsg.Text = "Cân lần 1 thành công!";
                }
                else { MessageBox.Show(operationResult.Message, operationResult.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
           else
            {
                _currentTruck.SecondWeight = weight;
                _currentTruck.CheckOutTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               operationResult = _truckInOut.SecondWeight(_truck.VoucherID, weight);
               if (operationResult.Success)
               {
                   _txtMsg.Text = "Cân lần 2 thành công!";

               }
               else { MessageBox.Show(operationResult.Message, operationResult.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
           BtnShow4Truck();
        }
        private void Weight()
        {
            //if (led1.ForeColor != Color.Blue)
            //    return;
            Weighting(Convert.ToDecimal(led1.Text));

           // btnUpWeightTruck.Enabled = true;//重量上传按钮
        }
        decimal weight = 0;
        #region ButtonClick
        private void btnSearchTruck_Click(object sender, EventArgs e)
        {
            SearchTruck();
        }

        private void btnBackTruck_Click(object sender, EventArgs e)
        {
            BtnShow4Truck();
            Reset();
        }

        private void btnInTruck_Click(object sender, EventArgs e)
        {
            CheckIn4Truck();
        }
        private void btnOutTruck_Click(object sender, EventArgs e)
        {
            CheckOut4Truck();
        }
        private void btnWeightTruck_Click(object sender, EventArgs e)
        {
            Weight();
        }
        #endregion
        #region Button Show
        //
        //Show Button Truck In Out
        //
        private void BtnShow4Truck()
        {
            btnSearchTruck.Visible = true;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;            
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = false;
            barTruck.Refresh();
            Reset();
        }
        private void BtnShow4TruckIn()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = true;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            //Reset();
        }
        private void BtnShow4TruckOut()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = true;
            btnWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            //Reset();
        }
        private void BtnShow4FirstWeight()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = true;
            //btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            //Reset();
        }
        private void BtnShow4SecondWeight()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = true;
            //btnUpWeightTruck.Visible = false;
            btnPrintTruck.Visible = false;
            btnBackTruck.Visible = false;
            barTruck.Refresh();
            //Reset();
        }
        private void BtnShow4Print()
        {
            btnSearchTruck.Visible = false;
            btnInTruck.Visible = false;
            btnOutTruck.Visible = false;
            btnWeightTruck.Visible = false;           
            btnPrintTruck.Visible = true;
            btnBackTruck.Visible = true;
            barTruck.Refresh();
            //Reset();
        }
        #endregion
        public delegate void VoidDelegate();
        Timer timer = new Timer();//Shuttle Vehicle Timer
        private void EGATE_Load(object sender, EventArgs e)
        {
            BtnShow4Truck();

            //serialPort.PortName = ConfigurationManager.AppSettings["StartingMonthColumn"].t
            serialPort.PortName = ConfigurationSettings.AppSettings["PORT"].ToString();
            this.Text = ConfigurationSettings.AppSettings["NAME"].ToString();
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MainMsg = "Serial failures : " + ex.Message + "|" + e.ToString();
            }
            //DataReceived
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }
        string Data = string.Empty;
        /// <summary>
        /// serialPort Data Received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Data += serialPort.ReadExisting();
            dataPackage.LastActive = DateTime.Now;

            //Add by Leo for new ToLeDo at FEPV 20170415  南门
            if (FEPVTOLEDO.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-TOLEDO-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            //北们
            if (MarcusP5SD.DoTransfer(Data, out weight))
            {
                dataPackage.Weight = weight;
                //MainMsg = DateTime.Now.ToString() + "-TOLEDO-" + weight.ToString();
                Data = string.Empty;
                return;
            }
            //if (BeiChang.DoTransfer(Data, out weight))
            //{
            //    dataPackage.Weight = weight;
            //    //MainMsg = DateTime.Now.ToString() + "-BeiChang-" + weight.ToString();
            //    Data = string.Empty;
            //    return;
            //}
            //if (DongChang.DoTransfer(Data, out weight))
            //{
            //    dataPackage.Weight = weight;
            //    //MainMsg = DateTime.Now.ToString() + "-DongChang-" + weight.ToString();
            //    Data = string.Empty;
            //    return;
            //}
            //if (YaoHua.DoTransfer(Data, out weight))
            //{
            //    dataPackage.Weight = weight;
            //    //MainMsg = DateTime.Now.ToString() + "-YaoHua-" + weight.ToString();
            //    Data = string.Empty;
            //    return;
            //}
            if (Data.Length > 1000)
                Data = string.Empty;
        }
        private void txtVehicleNO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter)
            {
                SearchTruck();
            }
        }
        
    }
}
