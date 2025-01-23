using QRGeneratorProject.Helpers;
using QRGeneratorProject.Interfaces;
using QRGeneratorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QRGeneratorProject.Services
{
    public class QRCodeGenerationService : IQRCodeGenerationService
    {
        private readonly IQRCodeService _qrCodeService;
        private readonly ILayoutService _layoutService;
        private readonly ITestDataGenerator _testDataGenerator;

        public QRCodeGenerationService(IQRCodeService qrCodeService, ILayoutService layoutService, ITestDataGenerator testDataGenerator)
        {
            _qrCodeService = qrCodeService;
            _layoutService = layoutService;
            _testDataGenerator = testDataGenerator;
        }

        public void GenerateSingleQRCode(string inputData, string bottomText)
        {
            string outputDirectory = DirectoryHelper.GetOutputDirectory();

            try
            {
                var file = _qrCodeService.GenerateQRCode(inputData, bottomText, outputDirectory);
                file.Image.Save(file.OutputPath, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"QR code has been saved as: {file.OutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GenerateMultipleQRCodes(string input, string bottomText)
        {
            List<FinalImage> files = new List<FinalImage>();
            string[] dataItemsArray = input.Split(',');

            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            try
            {
                foreach (var data in dataItemsArray)
                {
                    string trimmedData = data.Trim();
                    if (!string.IsNullOrEmpty(trimmedData))
                    {
                        var file = _qrCodeService.GenerateQRCode(trimmedData, bottomText, outputDirectory);
                        files.Add(file);
                    }
                }

                _layoutService.GenerateA4Layout(files);
                Console.WriteLine("All QR codes saved and compiled into an A4 layout.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GenerateTestQRCode()
        {
            var testData = _testDataGenerator.GenerateTestData();
            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            try
            {
                var file = _qrCodeService.GenerateQRCode(testData.Link, testData.FillerText, outputDirectory);
                file.Image.Save(file.OutputPath, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"Test QR code has been saved as: {file.OutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void GenerateMultipleTestQRCodes(int number)
        {
            string outputDirectory = DirectoryHelper.GetOutputDirectory();
            List<FinalImage> files = new List<FinalImage>();

            try
            {
                for (int i = 0; i < number; i++)
                {
                    var testData = _testDataGenerator.GenerateTestData();
                    var file = _qrCodeService.GenerateQRCode(testData.Link, testData.FillerText, outputDirectory);
                    files.Add(file);
                }

                _layoutService.GenerateA4Layout(files);
                Console.WriteLine($"{number} test QR codes saved and compiled into an A4 layout.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
