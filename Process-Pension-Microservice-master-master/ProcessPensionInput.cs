using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPension
{
    public class ProcessPensionInput
    {
        public string AadhaarNumber { get; set; }
        public double PensionAmount { get; set; }
        public int BankCharge { get; set; }
    }
    public enum PensionType
    {
        Self=1,
        Family=2
    }
    public class ProcessResponse
    {
        //public int ResponseId { get; set; }
        public int Status { get; set; }
        public double PensionAmount { get; set; }
    }
    public class ResultforValueCalculation
    {
        public string message { get; set; }
        public ValueforCalCulation result { get; set; }
    }
}
