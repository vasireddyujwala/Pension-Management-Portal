using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionDisbursement.Models
{
    public class PensionerDetail
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PAN { get; set; }
        public string AadhaarNumber { get; set; }
        public double SalaryEarned { get; set; }
        public double Allowances { get; set; }
        public PensionTypeValue PensionType { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public BankType BankType { get; set; }
    }

    public enum PensionTypeValue
    {
        Self = 1,
        Family = 2
    }

    public enum BankType
    {
        Public = 1,
        Private = 2
    }

}

