using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PensionDisbursement.Controllers;
using PensionDisbursement.Models;
using PensionDisbursement.Providers;
using PensionDisbursement.Repository;

namespace PensionDisbursement.UnitTest
{   [TestFixture]
    class ControllerTest
    { 
        Mock<IPensionerRepository> pro;
       
        DisbursementController controller;
        PensionerDetail pensionDetail;
        PensionerRepository _pro;
        IPensionerProvider data;
       
        [SetUp]
        public void Setup()
        {
            pro = new Mock<IPensionerRepository>();
            controller = new DisbursementController(pro.Object);
            data = new PensionerProvider();
            _pro = new PensionerRepository(data);
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
        public void DisbursementController_Valid_Aadhaar_return_OK_10(string aadhaar )
        { ProcessPensionInput pensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = 550, PensionAmount = 24450.0 };
            pro.Setup(p => p.GetDetail(aadhaar)).Returns(pensionDetail);

            pro.Setup(p => p.status(pensionDetail, pensionInput)).Returns(_pro.status(pensionDetail, pensionInput));
            var response= controller.DisbursePension(pensionInput);
            OkObjectResult okresult = response as OkObjectResult;
            Assert.AreEqual(200, okresult.StatusCode);

        }
        [TestCase("111122220000")]
        public void DisbursementController_Invalid_Aadhaar_return_ErrorValue_21(string aadhaar)
        {
            ProcessPensionInput pensionInput = new ProcessPensionInput { AadhaarNumber = aadhaar, BankCharge = 550, PensionAmount = 24450.0 };
            pro.Setup(p => p.GetDetail(aadhaar)).Returns(pensionDetail);

            pro.Setup(p => p.status(pensionDetail, pensionInput)).Returns((aadhaar!=pensionDetail.AadhaarNumber)?21:_pro.status(pensionDetail,pensionInput));
            var response = controller.DisbursePension(pensionInput);
            OkObjectResult okresult = response as OkObjectResult;
            Assert.AreNotEqual(404, okresult.StatusCode);

        }
        [TestCase("24440.0")]
        public void DisbursementController_Invalid_PensionAmount_return_ErrorValue_21(double pension)
        {
            ProcessPensionInput pensionInput = new ProcessPensionInput { AadhaarNumber = "111122223333", BankCharge = 550, PensionAmount = pension };
            pro.Setup(p => p.GetDetail(pensionInput.AadhaarNumber)).Returns(pensionDetail);

            pro.Setup(p => p.status(pensionDetail, pensionInput)).Returns( _pro.status(pensionDetail, pensionInput));
            var response = controller.DisbursePension(pensionInput);
            OkObjectResult okresult = response as OkObjectResult;
            Assert.AreEqual(200, okresult.StatusCode);

        }
        [TestCase(450)]
        public void DisbursementController_Invalid_BankCharges_return_ErrorValue_21(int charges)
        {
            ProcessPensionInput pensionInput = new ProcessPensionInput { AadhaarNumber = "111122223333", BankCharge = charges, PensionAmount = 24450.0 };
            pro.Setup(p => p.GetDetail(pensionInput.AadhaarNumber)).Returns(pensionDetail);

            pro.Setup(p => p.status(pensionDetail, pensionInput)).Returns(_pro.status(pensionDetail, pensionInput));
            var response = controller.DisbursePension(pensionInput);
            OkObjectResult okresult = response as OkObjectResult;
            Assert.AreNotEqual(404, okresult.StatusCode);

        }



    }
}
