using AuthorizationAPI.Model;
using AuthorizationAPI.Provider;
using AuthorizationAPI.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AuthTest
{
    public class Tests
    {
        List<PensionCredentials> user = new List<PensionCredentials>();
        
        [SetUp]
        public void Setup()
        {
            user = new List<PensionCredentials>()
            {
                new PensionCredentials{Username = "user1",Password = "user1"}
            };
            
        }


        [TestCase("user1","user1")]
        public void GetPensioner_Returns_Object(string uname,string pass)
        {
            Mock<IPensionProvider> mock = new Mock<IPensionProvider>();
            mock.Setup(p => p.GetList()).Returns(user);
            PensionProvider pro = new PensionProvider();
            PensionCredentials cred = new PensionCredentials { Username = uname, Password = pass };
            
            var penCred = pro.GetPensioner(cred);

            Assert.IsNotNull(penCred);
        }

        [TestCase("user3", "user3")]
        public void GetPensioner_Returns_Null(string uname, string pass)
        {

            Mock<IPensionProvider> mock = new Mock<IPensionProvider>();
            mock.Setup(p => p.GetList()).Returns(user);
            PensionProvider pro = new PensionProvider();
            PensionCredentials cred = new PensionCredentials { Username = uname, Password = pass };

            var penCred = pro.GetPensioner(cred);

            Assert.IsNull(penCred);

        }

        
    }
}