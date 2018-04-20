using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightingMachine.Contact;
using WeightingMachine.Implementation;
using WeightingMachine.Model;

namespace WeightingMachine.Helper
{
    public class Print
    {
        PrintDocument pDoc = new PrintDocument();
        public void PrintBill(bool isPaperPrint)
        {
            //isPaperPrint = true : Printing
            if (!isPaperPrint)
                return;

            if ((string)_Setting[0] == "H")
                pDoc.DefaultPageSettings.Landscape = true;

            pDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size 1", Convert.ToInt32(_Setting[2].Trim()), Convert.ToInt32(_Setting[1].Trim()));
            pDoc.Print();
        }

        string _PonderationID = string.Empty;
        string _Type = string.Empty;
        DataRow row = null;
        Truck currentTruck = new Truck();

        private string[] _Setting;
        //Setting="Paper Type; Paper Height; Paper Weight; IsPrintFrame; FrameX; FrameY; OrginX; OrginY";
        public string Setting
        {
            set
            {
                _Setting = value.Split(';');
            }
        }

        public Print(string PonderationID)
        {
            _PonderationID = PonderationID;
          
            ITruckDAL _truckDAL = new TruckDALService();
            //According to vehicle type printing
           // ReportBiz report = new ReportBiz();
            //DataRow rowsql = null;//report.GetMISReport("Q_PonderationPrint4FEIS", new string[] { "VoucherID", "Type", "Language" }, new object[] { _PonderationID, _Type, MyLanguage.Language }).Tables[0].Rows[0];
            //row = rowsql;
            currentTruck = _truckDAL.FindTruck(_PonderationID);
            this.pDoc.PrintPage += new PrintPageEventHandler(PrintWeightBill_FEPV);

        }
        public void PrintWeightBill_FEPV(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            //Print Frame 
            if (Convert.ToBoolean(_Setting[3].Trim()))
                e.Graphics.DrawImage(Resource.Bill, Convert.ToInt32(_Setting[4].Trim()), Convert.ToInt32(_Setting[5].Trim()));

            Font font = new Font("Times New Roman", 12, FontStyle.Bold);
            Font fonttime = new Font("Times New Roman", 10, FontStyle.Bold);

            int x = Convert.ToInt32(_Setting[6].Trim()),
                y = Convert.ToInt32(_Setting[7].Trim());
            for (int i = 0; i < 3; i++)
            {
                //e.Graphics.DrawString(currentTruck.VoucherID.ToString(),
                //    font, Brushes.Black, x, y - 28);
                e.Graphics.DrawString(currentTruck.CheckInTime.ToString(),
                    fonttime, Brushes.Black, x, y + 10);
                e.Graphics.DrawString(currentTruck.CheckOutTime.ToString(),
                    fonttime, Brushes.Black, x, y + 40);
                e.Graphics.DrawString(currentTruck.VehicleNO.ToString(),
                    font, Brushes.Black, x - 30, y + 65);
                #region Comment
        //        string Manufacturer_Name = row["Manufacturer"].ToString();
        //        int Manufacturer_Length = 0, MaxCharIn1Line = 0;
        //        for (int m = 0; m < Manufacturer_Name.Length; m++)
        //        {
        //            UnicodeCategory cat = char.GetUnicodeCategory(Manufacturer_Name[m]);
        //            if (cat == UnicodeCategory.OtherLetter)
        //            {
        //                Manufacturer_Length += 2; //Chinese charater
        //            }
        //            else
        //            {
        //                Manufacturer_Length += 1; //English charater
        //            }
        //            MaxCharIn1Line += 1;
        //            if (Manufacturer_Length >= 16)
        //                break;
        //        }
        //        if (Manufacturer_Length < 16)
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(0, MaxCharIn1Line),
        //                fonttime, Brushes.Black, x - 30, y + 113);
        //        else
        //        {
        //            int lastspace_index = Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" ") == -1 ? MaxCharIn1Line : (Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" "));
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(0, lastspace_index),
        //fonttime, Brushes.Black, x - 30, y + 100);
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(lastspace_index + 1),
        //fonttime, Brushes.Black, x - 30, y + 125);

        //        }
        //        //
        //        Manufacturer_Name = row["MaterielType"].ToString();
        //        Manufacturer_Length = 0;
        //        MaxCharIn1Line = 0;
        //        for (int m = 0; m < Manufacturer_Name.Length; m++)
        //        {
        //            UnicodeCategory cat = char.GetUnicodeCategory(Manufacturer_Name[m]);
        //            if (cat == UnicodeCategory.OtherLetter)
        //            {
        //                Manufacturer_Length += 2; //Chinese charater
        //            }
        //            else
        //            {
        //                Manufacturer_Length += 1; //English charater
        //            }
        //            MaxCharIn1Line += 1;
        //            if (Manufacturer_Length >= 16)
        //                break;
        //        }
        //        if (Manufacturer_Length < 16)
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(0, MaxCharIn1Line),
        //                fonttime, Brushes.Black, x - 30, y + 175);
        //        else
        //        {
        //            int lastspace_index = Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" ") == -1 ? MaxCharIn1Line : (Manufacturer_Name.Substring(0, MaxCharIn1Line).LastIndexOf(" "));
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(0, lastspace_index),
        //fonttime, Brushes.Black, x - 30, y + 165);
        //            e.Graphics.DrawString(Manufacturer_Name.Substring(lastspace_index + 1),
        //fonttime, Brushes.Black, x - 30, y + 185);

        //        }
                #endregion
                //
                //e.Graphics.DrawString(row["MaterielType"].ToString(),font, Brushes.Black, x - 30, y + 175);
                e.Graphics.DrawString(currentTruck.FirstWeight.ToString() + " Kg",
                    font, Brushes.Black, x + 22, y + 230);
                e.Graphics.DrawString(currentTruck.SecondWeight.ToString() + " Kg",
                    font, Brushes.Black, x + 22, y + 260);
                //e.Graphics.DrawString(row["TotalWeight"].ToString() + " Kg",
                //    font, Brushes.Black, x + 22, y + 290);
                //e.Graphics.DrawString(row["Weigher"].ToString().ToUpper(),
                //    font, Brushes.Black, x - 20, y + 335);
                x += 286;
            }
            e.HasMorePages = false;

        }
    }
}
