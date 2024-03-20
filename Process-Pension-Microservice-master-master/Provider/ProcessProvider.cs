using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPension.Provider
{
    public class ProcessProvider : IProcessProvider
    {
        /// <summary>
        /// Dependency Injection
        /// </summary>
        
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProcessProvider));
       
        /// <summary>
        /// Calling the Pension Detail Microservice
        /// </summary>
        /// <param name="aadhar"></param>
        /// <returns>value for calculations and client input</returns>
        public HttpResponseMessage PensionDetail(string aadhar)
        {
            ProcessProvider banktype = new ProcessProvider();
            
            HttpResponseMessage response = new HttpResponseMessage();
            string uriConn = "https://localhost:44391/";

            using (var client = new HttpClient())
            {
                client.BaseAddress =new Uri (uriConn);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    response = client.GetAsync("api/PensionerDetail/" + aadhar).Result;
                }
                catch(Exception e)
                {
                    _log4net.Error("Exception Occured" + e);
                    return null; 
                }
            }
            return response;
        }
        /// <summary>
        /// Getting the Values from Process Management Portal
        /// </summary>
        /// <param name="aadhar"></param>
        /// <returns></returns>
        public PensionDetail GetClientInfo(string aadhar)
        {
            PensionDetail res = new PensionDetail();
            HttpResponseMessage response = PensionDetail(aadhar);
            if (response == null)
            {
                res = null;
                return null;
            }
            string responseValue = response.Content.ReadAsStringAsync().Result;
            res = JsonConvert.DeserializeObject<PensionDetail>(responseValue);
            if(res==null)
            {
                return null;
            }
            return res;
        }
        /// <summary>
        /// Getting the values for calculation
        /// </summary>
        /// <param name="aadhar"></param>
        /// <returns>Values required for calculation</returns>
        public ValueforCalCulation GetCalculationValues(string aadhar)
        {
            PensionerDetail res = new PensionerDetail();
            HttpResponseMessage response = PensionDetail(aadhar);
            if (response == null)
            {
                res = null;
                return null;
            }
            string responseValue = response.Content.ReadAsStringAsync().Result;
            res = JsonConvert.DeserializeObject<PensionerDetail>(responseValue);

            ValueforCalCulation Values = new ValueforCalCulation()
            {
                SalaryEarned = res.SalaryEarned,
                Allowances = res.Allowances,
                BankType = (int)res.BankType,
                PensionType = (PensionType)res.PensionType
            };
            return Values;
        }


        public HttpResponseMessage GetDisbursementMessage(ProcessPensionInput processInput)
        {
            string uriConn2 = "https://localhost:44342/";
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri(uriConn2);
                StringContent content = new StringContent(JsonConvert.SerializeObject(processInput), Encoding.UTF8, "application/json");
                client1.DefaultRequestHeaders.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    response = client1.PostAsync("api/Disbursement", content).Result;
                }
                catch (Exception e)
                {
                    _log4net.Error("Exception Occured" + e);
                    response = null;
                }
            }

            return response;
        }

        public double CalcPensionAmount(int salary, int allowances, int bankType, PensionType pensionType)
        {
            double pensionAmount;
            if (pensionType == PensionType.Self)
                pensionAmount = (0.8 * salary) + allowances;
            else
                pensionAmount = (0.5 * salary) + allowances;

            if (bankType == 1)
                pensionAmount = pensionAmount + 500;
            else
                pensionAmount = pensionAmount + 550;

            return pensionAmount;
        }

    }
}
