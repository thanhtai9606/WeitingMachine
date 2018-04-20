using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeightingMachine
{
  
        class MarcusP5SD
        {
            #region Weight For Marcus P5SD Loadmeter
            //Marcus P5SD Loadmeter at FEPV Leo update 20180203
            //static Regex Regex4Transfer = new Regex(@"\s+(?<WT>\d+)KG");
            static Regex Regex4Transfer = new Regex(@"\s+(?<WT>\d+)\S+");
          

            public static bool DoTransfer(string Data, out decimal wt)
            {
                wt = 0;
                Match match = Regex4Transfer.Match(Data);
                if (match.Success)
                {
                    wt = Convert.ToDecimal(match.Groups["WT"].Value);
                    return true;
                }
                return false;
            }
            #endregion
        }
    
}
