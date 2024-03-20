using Pension_Management_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Repository
{
    public interface IPensionPortalRepo
    {
        public void AddResponse(PensionDetail detail);

        public void Save();

        
    }
}
