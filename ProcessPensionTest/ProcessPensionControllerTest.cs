using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProcessPension;
using ProcessPension.Controllers;
using ProcessPension.Provider;
using ProcessPension.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ProcessPensionControllerTest
{


    class ProcessPensionControllerTest
    {
        private Mock<IProcessRepo> repo;
        private ProcessPensionController processPensionController;
        PensionerInput pensionerInput = new PensionerInput()
        {
            Name = "Ritik",
            PAN = "BCFPN1234F",
            DateOfBirth = new DateTime(2000, 01, 01),
            PensionType = PensionTypeValue.Family,
            AadhaarNumber = "222222223333",
        };

        public void Setup()
        {
            //repo = new Mock<IProcessRepo>();

        }

        [Test]
        public void ProcessPension_WhenCalled_ReturnsPensionDetail()
        {
            ProcessPensionInput processpensioninput = new ProcessPensionInput()
            {
                AadhaarNumber = "111122223333",
                BankCharge = 550,
                PensionAmount = 25500
            };
            ValueforCalCulation valueforCalculation = new ValueforCalCulation()
            {
                BankType = 1,
                SalaryEarned = 25000,
                Allowances = 1000,
                PensionType = PensionType.Self
            };
            PensionDetail pensionDetail = new PensionDetail()
            {
                Name = "Sahil",
                DateOfBirth = new DateTime(1998 - 03 - 01),
                Pan = "BCFPN1234F",
                AadharNumber = "111122223333",
                PensionType = PensionType.Self,
                PensionAmount = 35000,
                BankType = 1,
                Status = 21,

            };
            repo = new Mock<IProcessRepo>();
            processPensionController = new ProcessPensionController(repo.Object);

            repo.Setup(r => r.GetClientInfo(pensionerInput.AadhaarNumber)).Returns(pensionDetail);
            repo.Setup(r => r.GetCalculationValues(pensionerInput.AadhaarNumber)).Returns(valueforCalculation);
            repo.Setup(r => r.GetDisbursementMessage(processpensioninput)).Returns(new HttpResponseMessage(HttpStatusCode.OK));
            repo.Setup(r => r.CalcPensionAmount(25000, 1000, 1, PensionType.Self)).Returns(21500.00);


            var result = processPensionController.ProcessPension(pensionerInput);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());


        }

        [Test]
        public void ProcessPension_WhenCalled_Returns_BadRequest()
        {
            ProcessPensionInput processpensioninput = new ProcessPensionInput()
            {
                AadhaarNumber = "222122223333",
                BankCharge = 550,
                PensionAmount = 25500
            };
            ValueforCalCulation valueforCalculation = new ValueforCalCulation()
            {
                BankType = 1,
                SalaryEarned = 25000,
                Allowances = 1000,
                PensionType = PensionType.Self
            };
            PensionDetail pensionDetail = null;
            repo = new Mock<IProcessRepo>();
            processPensionController = new ProcessPensionController(repo.Object);

            repo.Setup(r => r.GetClientInfo(pensionerInput.AadhaarNumber)).Returns(pensionDetail);
            repo.Setup(r => r.GetCalculationValues(pensionerInput.AadhaarNumber)).Returns(valueforCalculation);
            repo.Setup(r => r.GetDisbursementMessage(processpensioninput)).Returns(new HttpResponseMessage(HttpStatusCode.BadRequest));
            repo.Setup(r => r.CalcPensionAmount(25000, 1000, 1, PensionType.Self)).Returns(21500.00);


            var result = processPensionController.ProcessPension(pensionerInput);

            Assert.That(result, Is.Not.InstanceOf<OkObjectResult>());


        }
    }
}