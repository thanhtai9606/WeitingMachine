using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingMachine.Helper
{
    public class DataPackage
    {
        decimal _weight = -1m;
        public decimal Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                LastValidated = DateTime.Now;

                if (_weight != value)
                    LastChanged = DateTime.Now;

                _weight = value;
            }
        }

        public DateTime LastActive { get; set; }

        public DateTime LastValidated
        {
            get;
            private set;
        }

        public DateTime LastChanged
        {
            get;
            private set;
        }
    }
}
