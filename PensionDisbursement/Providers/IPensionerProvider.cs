using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PensionDisbursement.Models;

namespace PensionDisbursement.Providers
{
    public interface IPensionerProvider
    {
        public PensionerDetail GetData( string AadhaarNumber);
    }
}
