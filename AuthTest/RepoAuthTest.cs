using AuthorizationAPI.Model;
using AuthorizationAPI.Provider;
using AuthorizationAPI.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthTest
{
    class RepoAuthTest
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


            [TestCase("user1", "user1")]
            public void GetPensionerCred_Returns_Object(string uname, string pass)
            {
                PensionCredentials cred = new PensionCredentials { Username = uname, Password = pass };
                Mock<IPensionRepo> mock = new Mock<IPensionRepo>();
                mock.Setup(p => p.GetPensionerCred(cred)).Returns(user[0]);
                //PensionProvider pro = new PensionProvider();
               

                var penCred = mock.Object.GetPensionerCred(cred);

                Assert.IsNotNull(penCred);
            }

            [TestCase("user3", "user3")]
            public void GetPensionerCred_Returns_Null(string uname, string pass)
            {
                user[0] = null;
                PensionCredentials cred = new PensionCredentials { Username = uname, Password = pass };
                Mock<IPensionRepo> mock = new Mock<IPensionRepo>();
                mock.Setup(p => p.GetPensionerCred(cred)).Returns(user[0]);
                //PensionProvider pro = new PensionProvider();
               

                var penCred = mock.Object.GetPensionerCred(cred);

                Assert.IsNull(penCred);

            }
}
}
