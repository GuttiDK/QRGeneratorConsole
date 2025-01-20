using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGeneratorProject.Interfaces
{
    public interface ILayoutService
    {
        void GenerateA4Layout(List<string> qrCodePaths, string outputDirectory);
    }
}
