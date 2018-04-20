using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightingMachine.Helper
{
    public class OperationResult
    {
        public bool Success;
        public string Message;
        public string Caption;
        public OperationResult()
        {
            Success = true;
            Message = string.Empty;
            Caption = string.Empty;
        }
        public OperationResult(bool Success, string Message, string Caption)
        {
            this.Success = Success;
            this.Message = Message;
            this.Caption = Caption;
        }
    }
}
