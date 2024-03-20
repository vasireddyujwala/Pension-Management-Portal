using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using PensionDisbursement.Models;
using System.Web;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;
using log4net.Repository.Hierarchy;
using System.Xml;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using PensionDisbursement.Repository;

namespace PensionDisbursement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisbursementController : ControllerBase
    {
        private readonly IPensionerRepository _repo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DisbursementController));
        ProcessPensionResponse processPensionResponse = new ProcessPensionResponse();
        PensionerDetail pensionerDetail = null;
        public DisbursementController(IPensionerRepository repo)
        {
            _repo = repo;
        }
       
        
        // POST api/<DisbursementController>
        [HttpPost]
        public IActionResult DisbursePension(ProcessPensionInput processPensionInput)
        {
            _log4net.Info("Pension Disbursement started");
            _log4net.Info("Person with Aadhar Number " + processPensionInput.AadhaarNumber);

             pensionerDetail = _repo.GetDetail(processPensionInput.AadhaarNumber);


            _log4net.Info("PensionerDetail Present Name:" + pensionerDetail.Name);
               
            

            processPensionResponse.ProcessPensionStatusCode = _repo.status(pensionerDetail, processPensionInput);
            _log4net.Info(processPensionResponse.ProcessPensionStatusCode);
            return Ok(processPensionResponse);





        }
        
     
    }
}
