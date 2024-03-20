using AuthorizationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Provider
{
    public class PensionProvider : IPensionProvider
    {
        private static List<PensionCredentials> List = new List<PensionCredentials>()
        {
            new PensionCredentials{ Username = "Ananya", Password = "Ananya@123"},
            new PensionCredentials{ Username = "Ashu", Password = "Ashu@123"},
            new PensionCredentials{ Username = "Pratibha", Password = "Pratibha@123"},
            new PensionCredentials{ Username = "Akhil", Password = "Akhil@123"},
            new PensionCredentials{ Username = "Asad", Password = "Asad@123"},
            new PensionCredentials{ Username = "Himanshu", Password = "Himanshu@123"},
            new PensionCredentials{ Username = "Jonathan", Password = "Jonathan@123"}
            //new PensionCredentials{ Username = "pensioner1", Password="pensioner1" }
        };
        public List<PensionCredentials> GetList()
        {
            return List;
        }

        public PensionCredentials GetPensioner(PensionCredentials cred)
        {
            List<PensionCredentials> rList = GetList();
            PensionCredentials penCred = rList.FirstOrDefault(user => user.Username == cred.Username && user.Password == cred.Password);

            return penCred;
        }
    }
}
