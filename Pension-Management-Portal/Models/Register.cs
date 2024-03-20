using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Models
{
    public class Register
    {
        [Key]
        [DisplayName("Pensioner Id")]
        public int PensionerId { get; set; }
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime Dateofbirth { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only Numbers and Alphabets acceptable")]
        [DisplayName("PAN Card")]
        public string PAN { get; set; }
        [DisplayName("Salary")]
        public int SalaryEarned { get; set; }
        [DisplayName("Allowances")]
        public int Allowances { get; set; }
        [Required]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "Should be combination of 12-digits ONLY")]
        [DisplayName("Aadhar Number")]
        public string AadharNumber { get; set; }
        public PensionTypeValue PensionType { get; set; }
        [DisplayName("Bank Name")]
        public string BankName { get; set; }
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
        [DisplayName("Bank Type")]
        public BankType BankType { get; set; }
        [DisplayName("Password")]

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "Password must have minimum 8 Characters"), MinLength(8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }
        

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please enter confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match, Try again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}