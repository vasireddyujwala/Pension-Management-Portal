using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Models
{
    public class PensionerInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only Numbers and Alphabets acceptable")]
        public string PAN { get; set; }
        [Required]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Should be combination of 12-digits ONLY")]
        public string AadhaarNumber { get; set; }
        [Required]
        public PensionTypeValue PensionType { get; set; }
    }

    public enum PensionTypeValue
    {
        Self = 1,
        Family = 2
    }
}
