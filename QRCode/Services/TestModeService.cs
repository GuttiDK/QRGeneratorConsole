using QRGeneratorProject.Interfaces;
using System;

namespace QRGeneratorProject.Services
{
    public class TestModeService : ITestModeService
    {
        private bool _testModeActive;

        public void ToggleTestMode()
        {
            if (IsDebugMode())
            {
                _testModeActive = !_testModeActive;
                Console.WriteLine($"Test Mode is now {(_testModeActive ? "Enabled" : "Disabled")}");
            }
        }

        public bool IsTestModeActive()
        {
            return _testModeActive;
        }

        private bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
