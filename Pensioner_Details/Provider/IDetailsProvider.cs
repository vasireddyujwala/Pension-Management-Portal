using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensioner_Details.Provider
{
    public interface IDetailsProvider
    {
        public PensionerDetail GetDetailsByAadhar(string aadhar);
        
    }
}
