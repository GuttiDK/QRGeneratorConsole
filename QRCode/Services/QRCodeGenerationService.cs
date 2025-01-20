using QRGeneratorProject.Helpers;
using System;
using System.Collections.Generic;

namespace QRGeneratorProject.Services
{
    public class QRCodeGenerationService
    {
        private readonly QRCodeService _qrCodeService;
        private readonly LayoutService _layoutService;
        private readonly TestModeService _testModeService;

        public QRCodeGenerationService(TestModeService testModeService)
        {
            _qrCodeService = new QRCodeService();
            _layoutService = new LayoutService();
            _testModeService = new TestModeService();
        }

        public void GenerateSingleQRCode(string inputData, string bottomText)
        {
            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            try
            {
                string savedFilePath = _qrCodeService.GenerateQRCode(inputData, bottomText, outputDirectory);
                Console.WriteLine($"QR code has been saved as: {savedFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GenerateMultipleQRCodes(string input, string bottomText)
        {
            List<string> filePaths = new List<string>();
            string[] dataItemsArray = input.Split(',');

            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            try
            {
                foreach (var data in dataItemsArray)
                {
                    string trimmedData = data.Trim();
                    if (!string.IsNullOrEmpty(trimmedData))
                    {
                        string savedFilePath = _qrCodeService.GenerateQRCode(trimmedData, bottomText, outputDirectory);
                        filePaths.Add(savedFilePath);
                    }
                }

                _layoutService.GenerateA4Layout(filePaths, outputDirectory);
                Console.WriteLine("All QR codes saved and compiled into an A4 layout.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
