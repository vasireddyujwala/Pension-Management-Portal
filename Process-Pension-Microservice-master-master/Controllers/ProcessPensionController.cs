using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcessPension.Provider;
using ProcessPension.Repository;

namespace ProcessPension.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPensionController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProcessPensionController));
       
        private IProcessRepo _repo;
        private IProcessProvider pro;
        private ProcessResponse processResponse;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="iConfig"></param>
        public ProcessPensionController(IProcessRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 1. This method is taking values given by MVC Client i.e. Pension Management Portal as Parameter
        /// 2. Calling the Pension Detail Microservice and checking all the values
        /// 3. Calling the Pension Disbursement Microservice to get the Status Code
        /// </summary>
        /// <param name="processPensionInput"></param>
        /// <returns>Details to be displayed on the MVC Client</returns>
        [Route("[action]")]
        [HttpPost]
        public IActionResult ProcessPension(PensionerInput processPensionInput)
        {
            _log4net.Info("Pensioner details invoked from Client Input");
            PensionerInput client = new PensionerInput();
            client.Name = processPensionInput.Name;
            client.AadhaarNumber = processPensionInput.AadhaarNumber;
            client.PAN = processPensionInput.PAN;
            client.DateOfBirth = processPensionInput.DateOfBirth;
            client.PensionType = processPensionInput.PensionType;

            //repo = new ProcessRepo(pro);
            PensionDetail pensionDetail = _repo.GetClientInfo(client.AadhaarNumber);

            if (pensionDetail == null)
            {
                PensionDetail mvc = new PensionDetail();
                mvc.Name = "";
                mvc.Pan = "";
                mvc.PensionAmount = 0;
                mvc.DateOfBirth = new DateTime(2000, 01, 01);
                mvc.BankType = 1;
                mvc.AadharNumber = "***";
                mvc.Status = 20;

                return NotFound();
            }



            double pensionAmount;

            ValueforCalCulation pensionerInfo = _repo.GetCalculationValues(client.AadhaarNumber);
            pensionAmount = CalculatePensionAmount(pensionerInfo.SalaryEarned, pensionerInfo.Allowances, pensionerInfo.BankType, pensionerInfo.PensionType);

            int statusCode;

            PensionDetail mvcClientOutput = new PensionDetail();

            if (client.AadhaarNumber.Equals(pensionDetail.AadharNumber))
            {
                mvcClientOutput.Name = pensionDetail.Name;
                mvcClientOutput.Pan = pensionDetail.Pan;
                mvcClientOutput.PensionAmount = pensionAmount;
                mvcClientOutput.DateOfBirth = pensionDetail.DateOfBirth.Date;
                mvcClientOutput.PensionType = pensionerInfo.PensionType;
                mvcClientOutput.BankType = pensionerInfo.BankType;
                mvcClientOutput.AadharNumber = pensionDetail.AadharNumber;
                mvcClientOutput.Status = 20;
            }
            else
            {
                mvcClientOutput.Name = "";
                mvcClientOutput.Pan = "";
                mvcClientOutput.PensionAmount = 0;
                mvcClientOutput.DateOfBirth = new DateTime(2000, 01, 01);
                mvcClientOutput.PensionType = pensionerInfo.PensionType;
                mvcClientOutput.BankType = 1;
                mvcClientOutput.AadharNumber = "****";
                mvcClientOutput.Status = 21;

                //return mvcClientOutput;
            }

            ProcessPensionInput input = new ProcessPensionInput();
            input.AadhaarNumber = mvcClientOutput.AadharNumber;
            input.PensionAmount = mvcClientOutput.PensionAmount;
            if (mvcClientOutput.BankType == 1)
            {
                input.BankCharge = 500;
            }
            else
            {
                input.BankCharge = 550;
            }

            

           
            HttpResponseMessage response = _repo.GetDisbursementMessage(input);
            
            if (response != null)
            {
                string status = response.Content.ReadAsStringAsync().Result;
                //statusCode = Int32.Parse(status);
                ProcessPensionResponse res = JsonConvert.DeserializeObject<ProcessPensionResponse>(status);

                statusCode = res.processPensionStatusCode;
                processResponse = new ProcessResponse()
                {
                    Status = statusCode,
                    PensionAmount = mvcClientOutput.PensionAmount
                };

                return Ok(processResponse);
            }
            return Ok(processResponse);
        }

        private double CalculatePensionAmount(int salary, int allowances,int bankType , PensionType pensionType)
        {
            double pensionAmount;

            //repo = new ProcessRepo(pro);

            pensionAmount = _repo.CalcPensionAmount(salary, allowances, bankType, pensionType);

            return pensionAmount;
        }

    }



    public class ProcessPensionResponse
    {
        
        public int processPensionStatusCode { get; set; }
    }

}
