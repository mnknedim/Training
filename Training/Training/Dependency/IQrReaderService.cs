using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Training.Dependency
{
    public interface IQrReaderService
    {
       Task<string> ScannAsync();
       //Task<string> CallHtml();
    }
}
