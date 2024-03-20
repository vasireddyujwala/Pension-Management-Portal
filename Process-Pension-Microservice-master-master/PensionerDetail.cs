using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPension
{
    public class PensionerDetail
    {
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Pan { get; set; }
        public int SalaryEarned { get; set; }
        public int Allowances { get; set; }
        public string AadharNumber { get; set; }
        public PensionTypeValue PensionType { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public BankType BankType { get; set; }
    }

    public enum BankType
    {
        Public = 1,
        Private = 2
    }
}
