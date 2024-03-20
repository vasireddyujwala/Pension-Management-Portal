using Microsoft.Extensions.Configuration;
using ProcessPension.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessPension.Repository
{
    public class ProcessRepo : IProcessRepo
    {
        private IProcessProvider provider;

        public ProcessRepo(IProcessProvider _provider)
        {
            provider = _provider;
        }

       
        public double CalcPensionAmount(int salary, int allowances, int bankType, PensionType pensionType)
        {
            double pensionAmt;
            //provider = new ProcessProvider();

            pensionAmt = provider.CalcPensionAmount(salary, allowances, bankType, pensionType);
            return pensionAmt;
        }

        public ValueforCalCulation GetCalculationValues(string aadhar)
        {
            
            //provider = new ProcessProvider();
            ValueforCalCulation value = provider.GetCalculationValues(aadhar);

            return value;

        }

        public PensionDetail GetClientInfo(string aadhar)
        {
            //provider = new ProcessProvider();
            PensionDetail proInput = provider.GetClientInfo(aadhar);

            return proInput;
        }

        public HttpResponseMessage GetDisbursementMessage(ProcessPensionInput pensionDetail)
        {
           // provider = new ProcessProvider();

            HttpResponseMessage response = provider.GetDisbursementMessage(pensionDetail);

            return response;
        }

        
    }
}
