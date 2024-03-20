using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessPension.Repository
{
    public interface IProcessRepo
    {

        public PensionDetail GetClientInfo(string aadhar);

        public ValueforCalCulation GetCalculationValues(string aadhar);

        public HttpResponseMessage GetDisbursementMessage(ProcessPensionInput pensionDetail);

        public double CalcPensionAmount(int salary, int allowances, int bankType, PensionType pensionType);
        
    }
}
