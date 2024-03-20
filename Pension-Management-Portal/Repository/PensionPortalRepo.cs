using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pension_Management_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pension_Management_Portal.Repository
{
    public class PensionPortalRepo : IPensionPortalRepo
    {
        private PensionContext context;

        public PensionPortalRepo(PensionContext _context)
        {
            context = _context;
        }
        public void AddResponse(PensionDetail detail)
        {
            context.Responses.Add(detail);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        

    }
}
