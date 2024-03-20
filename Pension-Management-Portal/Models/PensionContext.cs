using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Models
{
    public class PensionContext : DbContext
    {
        public PensionContext(DbContextOptions<PensionContext> options) : base(options)
        {

        }

        public DbSet<PensionDetail> Responses { get; set; }
        public DbSet<Register> PensionerDetails { get; set; }
    }
}
