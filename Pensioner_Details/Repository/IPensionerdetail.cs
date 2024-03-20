using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensioner_Details.Repository
{
    public interface IPensionerdetail
    {
        public PensionerDetail PensionerDetailByAadhar(string aadhar);
        public List<PensionerDetail> GetDetailsCsv();

    }
}
