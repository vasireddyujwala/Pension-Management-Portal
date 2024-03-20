using Microsoft.Extensions.Configuration;
using Pensioner_Details.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensioner_Details.Provider
{
    public class DetailsProvider : IDetailsProvider
    {
        


        private IPensionerdetail detail;
       
        public PensionerDetail GetDetailsByAadhar(string aadhar)
        {
            detail = new PensionerRepository();
            PensionerDetail pensioner = detail.PensionerDetailByAadhar(aadhar);
            return pensioner;
        }
        public void DeleteByAadhar(string aadhar)
        {

            detail = new PensionerRepository();


        }
        
    }
}
