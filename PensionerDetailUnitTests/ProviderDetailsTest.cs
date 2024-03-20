using Moq;
using NUnit.Framework;
using Pensioner_Details;
using Pensioner_Details.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace PensionerDetailUnitTests
{
    class ProviderDetailsTest
    {
        List<PensionerDetail> details;
        [SetUp]
        public void Setup()
        {
            details = new List<PensionerDetail>()
            {
                new PensionerDetail()
                {
                    Name = "Dipika",
                    Dateofbirth = Convert.ToDateTime("1998-03-01"),
                    Pan = "BCFPN1234F",
                    AadharNumber = "111122223333",
                    SalaryEarned = 40000,
                    Allowances = 5000,
                    PensionType = (PensionTypeValue)(2),
                    BankName ="HDFC",
                    AccountNumber = "123456789876",
                    BankType = (BankType)(2)
                }
            };
        }

        [TestCase("111122223333")]
        public void GetDetailsByAadhar_Returns_Object(string aadhar)
        {
            Mock<IDetailsProvider> mock = new Mock<IDetailsProvider>();

            mock.Setup(p => p.GetDetailsByAadhar(aadhar)).Returns(details[0]);

            PensionerDetail det = mock.Object.GetDetailsByAadhar(aadhar);

            Assert.AreEqual(det, details[0]);
        }

        [TestCase("111122223333")]
        public void GetDetailsByAadhar_Returns_Null(string aadhar)
        {
            Mock<IDetailsProvider> mock = new Mock<IDetailsProvider>();

            mock.Setup(p => p.GetDetailsByAadhar(aadhar)).Returns(new PensionerDetail());

            PensionerDetail det = mock.Object.GetDetailsByAadhar(aadhar);

            Assert.AreNotEqual(det, details[0]);
        }
    }
}
