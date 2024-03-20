using Moq;
using NUnit.Framework;
using PensionDisbursement.Models;
using PensionDisbursement.Providers;
using PensionDisbursement.Repository;
using System;

using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace PensionDisbursement.UnitTest
{
    [TestFixture]
    class ProviderTest
    {
        Mock<IPensionerProvider> pro = new Mock<IPensionerProvider>();
        PensionerProvider _pro = new PensionerProvider();
        
        HttpResponseMessage responseMessage;
        HttpResponseMessage testResponse;
        HttpStatusCode statusCode = HttpStatusCode.OK;
      //  ValueforCalCulation valueforCalCulation;
        PensionerDetail pensionDetail;
        
        [SetUp]
        //Dipika,1998-03-01,BCFPN1234F,111122223333,40000,5000,2,HDFC,123456789876,2
        public void Setup()
        {
            responseMessage = new HttpResponseMessage(statusCode);
            testResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
            pensionDetail = new PensionerDetail


            {
                Name = "Dipika",
                DateOfBirth = Convert.ToDateTime("1998-03-01"),
                PAN = "BCFPN1234F",
                AadhaarNumber = "111122223333",
                SalaryEarned = 40000,
                Allowances = 5000,
                PensionType = (PensionTypeValue)(2),
                BankName = "HDFC",
                AccountNumber = "123456789876",
                BankType = (BankType)(2)
            };
            
        }

        [TestCase("111122223333")]
        public void PensionerDetailByAadhar_Returns_object(string aadhar)
        { PensionerDetail resp = null;
      
            pro.Setup(p => p.GetData(aadhar)).Returns(pensionDetail);
             resp = pro.Object.GetData(aadhar);
            if (resp.AadhaarNumber==aadhar) testResponse = new HttpResponseMessage(HttpStatusCode.OK);
               
            Assert.IsTrue(testResponse.StatusCode==HttpStatusCode.OK);
            }
        [TestCase("110022993333")]
        public void PensionerDetail_InvalidAadhar_Returns_null(string aadhar)
        {
            PensionerDetail resp = null;

            pro.Setup(p => p.GetData(aadhar)).Returns(pensionDetail);
            resp = pro.Object.GetData(aadhar);
            if (resp.AadhaarNumber == aadhar) testResponse = new HttpResponseMessage(HttpStatusCode.OK);

            Assert.IsTrue(testResponse.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
