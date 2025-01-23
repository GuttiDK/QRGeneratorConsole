using QRGeneratorProject.Models;
using System.Collections.Generic;

namespace QRGeneratorProject.Interfaces
{
    public interface ILayoutService
    {
        void GenerateA4Layout(List<FinalImage> qrCodePaths);
    }
}
