using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLinking
{
    public interface IOpenAppService
    {
        Task<bool> LaunchAsync(string stringUri, string appPackageName);
    }
}
