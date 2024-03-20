using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PensionDisbursement.Models;

namespace PensionDisbursement.Repository
{
    public interface IPensionerRepository
    {
      public PensionerDetail GetDetail(string AadhaarNumber);
      public int status(PensionerDetail pensionerDetail,ProcessPensionInput processPensionInput);
       
    }
}
