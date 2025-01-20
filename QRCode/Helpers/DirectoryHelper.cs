using System;
using System.IO;

namespace QRGeneratorProject.Helpers
{
    public static class DirectoryHelper
    {
        public static string GetOutputDirectory()
        {
            string outputDirectory = KnownFolders.GetPath(KnownFolder.Downloads);
            if (string.IsNullOrEmpty(outputDirectory))
            {
                Console.WriteLine("Downloads folder not found. Using default location.");
                outputDirectory = @"C:\QRCodeOutput";
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            return outputDirectory;
        }
    }
}
