using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Models
{
    public class PensionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Serial Number")]
        public int DetailId { get; set; }
        [DisplayName("Pension Amount")]
        public double PensionAmount { get; set; }
        [DisplayName("Status Code")]
        public int Status { get; set; }
    }

    
}
