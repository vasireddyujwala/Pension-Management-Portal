using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PensionDisbursement.Models
{
    public class ProcessPensionInput
    {  [RegularExpression(@"^[0-9]{12}$", ErrorMessage = "enter  12 Digit Valid only")]
   
        public string AadhaarNumber { get; set; }
        public double PensionAmount { get; set; }
        public int BankCharge { get; set; }
    }
}
