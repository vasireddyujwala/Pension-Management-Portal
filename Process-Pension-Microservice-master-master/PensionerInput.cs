using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPension
{
    public class PensionerInput
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PAN { get; set; }
        public string AadhaarNumber { get; set; }
        public PensionTypeValue PensionType { get; set; }
    }

    public enum PensionTypeValue
    {
        Self = 1,
        Family = 2
    }
}
