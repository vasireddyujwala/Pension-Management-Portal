using Castle.Core.Internal;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using Pensioner_Details;
using Pensioner_Details.Repository;
using System;
using System.Collections.Generic;

namespace PensionerDetailUnitTests
{
    public class Tests
    {
        private const string V = "details.csv";
        List<PensionerDetail> details;
        [SetUp]
        //Dipika,1998-03-01,BCFPN1234F,111122223333,40000,5000,2,HDFC,123456789876,2
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
        public void PensionerDetailByAadhar_Returns_object(string aadhar)
        {
           
            Mock<IPensionerdetail> mock = new Mock<IPensionerdetail>();

            mock.Setup(p => p.GetDetailsCsv()).Returns(details);

            PensionerRepository pro = new PensionerRepository();

            //details = pro.GetDetailsCsv();

            PensionerDetail a = pro.PensionerDetailByAadhar(aadhar);

            Assert.IsNotNull(a);
            
        }

        [TestCase("111122823333")]
        public void PensionerDetailByAadhar_Returns_Null(string aadhar)
        {

            Mock<IPensionerdetail> mock = new Mock<IPensionerdetail>();

            mock.Setup(p => p.GetDetailsCsv()).Returns(details);

            PensionerRepository pro = new PensionerRepository();

            //details = pro.GetDetailsCsv();

            PensionerDetail a = pro.PensionerDetailByAadhar(aadhar);

            Assert.IsNull(a);

        }

        [Test]
        public void GetDetailsCsv_Returns_List()
        {

            Mock<IPensionerdetail> mock = new Mock<IPensionerdetail>();

            mock.Setup(p => p.GetDetailsCsv()).Returns(details);

            //PensionerRepository pro = new PensionerRepository();

            //details = pro.GetDetailsCsv();

            List<PensionerDetail> a = mock.Object.GetDetailsCsv();

            Assert.AreEqual(a.Count,details.Count);

        }

        [Test]
        public void GetDetailsCsv_Returns_Null()
        {

            Mock<IPensionerdetail> mock = new Mock<IPensionerdetail>();

            mock.Setup(p => p.GetDetailsCsv()).Returns(new List<PensionerDetail>());

            //PensionerRepository pro = new PensionerRepository();

            //details = pro.GetDetailsCsv();

            List<PensionerDetail> a = mock.Object.GetDetailsCsv();

            Assert.AreNotEqual(a.Count, details.Count);

        }
    }
}