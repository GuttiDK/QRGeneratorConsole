using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGeneratorProject.Interfaces
{
    public interface IQRCodeService
    {
        string GenerateQRCode(string inputData, string bottomText, string outputDirectory);
    }
}
