using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<PensionContext>();
            //    if(!context.PensionerDetails.Any())
            //    {
            //        context.AddRange(new Register()
            //        {
            //            Name = "Aaaaa",
            //            Dateofbirth = DateTime.Now,
            //            PAN = "ABCDEFG",
            //            SalaryEarned = 30000,
            //            Allowances = 1800,
            //            AadharNumber = "123456789101",
            //            PensionType = (PensionTypeValue)1,
            //            BankName = "SBI",
            //            AccountNumber = "123456789101",
            //            BankType = (BankType)2,
            //            Password = "Aaaaa@704",
            //            ConfirmPassword = "Aaaaa@704"


            //        });
            //        context.SaveChanges();
            //    }
        }
    }
}
