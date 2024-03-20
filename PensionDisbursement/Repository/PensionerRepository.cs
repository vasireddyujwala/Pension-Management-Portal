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
using PensionDisbursement.Controllers;
using PensionDisbursement.Providers;
using System.Diagnostics;
using log4net.Repository.Hierarchy;
using log4net;
using System.Xml;
using System.Reflection;

namespace PensionDisbursement.Repository
{
    public class PensionerRepository:IPensionerRepository
    {
        private readonly IPensionerProvider _provider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerRepository));
        ProcessPensionResponse processPensionResponse = new ProcessPensionResponse();
       
      public PensionerRepository(IPensionerProvider provider)
        {
            _provider = provider;
        }
       
        
        public PensionerDetail GetDetail(string AadhaarNumber)
        {
            
            PensionerDetail pensionerDetail = null;

            _log4net.Info("Requesting for data");

            
           
            pensionerDetail= _provider.GetData(AadhaarNumber);
            _log4net.Info("Data Fetched");
            return pensionerDetail;



        } 
       public  int status(PensionerDetail pensionerDetail,ProcessPensionInput input)
       {
            if (input.PensionAmount == 0)
                return 21;
            if (input.BankCharge == 0 || (pensionerDetail.BankType == BankType.Private && input.BankCharge != 550) ||
                   (pensionerDetail.BankType == BankType.Public && input.BankCharge != 500))
                return 21;
            double rate = (pensionerDetail.PensionType == PensionTypeValue.Family) ? 0.5 : 0.8;

            double pension = (rate * pensionerDetail.SalaryEarned) + pensionerDetail.Allowances + input.BankCharge;
            //_log4net.Debug("pension" + pension);
            if (pension != input.PensionAmount)
                return 21;
            return 10;




        }
    }
}
