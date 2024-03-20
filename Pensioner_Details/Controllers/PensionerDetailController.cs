using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pensioner_Details.Provider;
using Pensioner_Details.Repository;

namespace Pensioner_Details.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PensionerDetailController));
        private IDetailsProvider detail;

        public PensionerDetailController(IDetailsProvider _Idetail)
        {
            detail = _Idetail;
        }
        ///Getting the details of the pensioner details from csv file by giving Aadhar Number
        ///Summary
        /// <returns> pensioner Values</returns>
         
        // GET: api/PensionerDetail/5
        [HttpGet("{aadhar}")]
        public IActionResult PensionerDetailByAadhar(string aadhar)
        {
            detail = new DetailsProvider();
            PensionerDetail pensioner = detail.GetDetailsByAadhar(aadhar);
            return Ok(pensioner);
        }

        [HttpDelete("{aadhar}")]
        public IActionResult Delete(string aadhar)
        {
            List<String> lines = new List<string>();
            int count = 0;
            using (StreamReader sr = new StreamReader(@".\details.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if (values[3].Equals(aadhar))
                    {
                        count = 1;
                        continue;
                      
                    }
                    lines.Add(line);

                }
            }
            if (count == 1)
            {
                using (StreamWriter sw = new StreamWriter(@".\details.csv"))
                {
                    foreach (var i in lines)
                        sw.WriteLine(i);
                }
                return new OkResult();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add([FromBody] PensionerDetail detail)
        {
            List<String> lines = new List<string>();
            int count = 0;
            using (StreamReader sr = new StreamReader(@".\details.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        string[] values = line.Split(',');
                        if (values.Contains(detail.AadharNumber))
                        {
                            count = 1;
                        }
                        lines.Add(line);
                    }
                }

                line = detail.Name + "," + detail.Dateofbirth + "," + detail.Pan + "," + detail.AadharNumber + "," + detail.SalaryEarned + "," + detail.Allowances + "," + (int)detail.PensionType + "," + detail.BankName + "," + detail.AccountNumber + "," + (int)detail.BankType;
                lines.Add(line);
            }
            if (count == 0)
            {
                using (StreamWriter sw = new StreamWriter(@".\details.csv"))
                {
                    foreach (var i in lines)
                        sw.WriteLine(i);
                }
                return Ok("Sucessfully Added");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPatch("{aadhar}")]
        public IActionResult update([FromBody] PensionerDetail detail, string aadhar)
        {
            List<String> lines = new List<string>();
            int count = 0;
            using (StreamReader sr = new StreamReader(@".\details.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if (values[3].Equals(aadhar))
                    {
                        count = 1;
                        continue;

                    }
                    lines.Add(line);

                }
            }
            if (count == 1)
            {
                using (StreamWriter sw = new StreamWriter(@".\details.csv"))
                {
                    foreach (var i in lines)
                        sw.WriteLine(i);
                }
            }
            //return Ok();
            List<String> lines1 = new List<string>();
            int count1 = 0;
            using (StreamReader sr = new StreamReader(@".\details.csv"))
            {
                string line2;
                while ((line2 = sr.ReadLine()) != null)
                {
                    if (line2.Contains(","))
                    {
                        string[] values = line2.Split(',');
                        if (values.Contains(detail.AadharNumber))
                        {
                            count1 = 1;
                        }
                        lines1.Add(line2);
                    }
                }

                line2 = detail.Name + "," + detail.Dateofbirth + "," + detail.Pan + "," + detail.AadharNumber + "," + detail.SalaryEarned + "," + detail.Allowances + "," + (int)detail.PensionType + "," + detail.BankName + "," + detail.AccountNumber + "," + (int)detail.BankType;
                lines1.Add(line2);
            }
            if (count1 == 0)
            {
                using (StreamWriter sw = new StreamWriter(@".\details.csv"))
                {
                    foreach (var i in lines1)
                        sw.WriteLine(i);
                }
            }
            else
                return BadRequest("Not found");
            return Ok("Updated");
        }





    }
}

