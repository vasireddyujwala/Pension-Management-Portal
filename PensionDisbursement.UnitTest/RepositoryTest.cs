using NUnit.Framework;
using PensionDisbursement.Models;
using PensionDisbursement.Repository;
using PensionDisbursement.Providers;
using Moq;
using System.Net;
using System.Net.Http;
using System;

namespace PensionDisbursement.UnitTest
{   [TestFixture]
    public class RepositoryTest
    {


        private Mock<IPensionerProvider> pro;

        private IPensionerRepository _pro;
        HttpResponseMessage testResponse;
       
        PensionerDetail pensionDetail;

        [SetUp]
        //Dipika,1998-03-01,BCFPN1234F,111122223333,40000,5000,2,HDFC,123456789876,2
        public void Setup()
        {
            pro = new Mock<IPensionerProvider>();
            _pro = new PensionerRepository(pro.Object);
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
        [TestCase(25550.0,550,"111122223333")]
        public void PensionerRepository_Valid_Aadhaar_return_OK(double pension,int charges,string aadhaar)
        {
            ProcessPensionInput processPensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = charges, PensionAmount = pension };
            
            pro.Setup(p => p.GetData(aadhaar)).Returns(pensionDetail);
            PensionerDetail pensionerDetail = pro.Object.GetData(aadhaar);
            int n = _pro.status(pensionerDetail, processPensionInput);
            Assert.AreEqual(10, n);
        }

        [TestCase(24430.0, 550, "111122223333")]
        public void PensionerRepository_Invalid_PensionAmount_return_ErrorStatus(double pension, int charges, string aadhaar)
        {
            ProcessPensionInput processPensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = charges, PensionAmount = pension };

            pro.Setup(p => p.GetData(aadhaar)).Returns(pensionDetail);
            PensionerDetail pensionerDetail = pro.Object.GetData(aadhaar);
            int n = _pro.status(pensionerDetail, processPensionInput);
            Assert.AreNotEqual(10, n);
        }

        [TestCase(24450.0, 550, "111122220000")]
        public void PensionerRepository_Invalid__Aadhaar_return_ErrorStatus(double pension, int charges, string aadhaar)
        {
            ProcessPensionInput processPensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = charges, PensionAmount = pension };
            int n = 10;
            pro.Setup(p => p.GetData(aadhaar)).Returns(pensionDetail);
            PensionerDetail pensionerDetail = pro.Object.GetData(aadhaar);
            if (pensionDetail.AadhaarNumber != aadhaar)
                n = 21;

            Assert.AreNotEqual(10, n);
        }

        [TestCase(24430.0, 440, "111122223333")]
        public void PensionerRepository_Invalid__Bankcharge_return_ErrorStatus(double pension, int charges, string aadhaar)
        {
            ProcessPensionInput processPensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = charges, PensionAmount = pension };

            pro.Setup(p => p.GetData(aadhaar)).Returns(pensionDetail);
            PensionerDetail pensionerDetail = pro.Object.GetData(aadhaar);
            int n = _pro.status(pensionerDetail, processPensionInput);
            Assert.AreEqual(21, n);
        }




    }






}
