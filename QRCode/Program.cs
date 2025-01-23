using Microsoft.Extensions.DependencyInjection;
using QRGeneratorProject.Interfaces;
using QRGeneratorProject.Services;

namespace QRGeneratorProject
{
    class Program
    {
        static void Main()
        {
            // Setup Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IQRCodeService, QRCodeService>() 
                .AddSingleton<ILayoutService, LayoutService>() 
                .AddSingleton<ITestModeService, TestModeService>() 
                .AddSingleton<ITestDataGenerator, TestDataGenerator>() 
                .AddSingleton<IMenuService, MenuService>()
                .AddSingleton<IQRCodeGenerationService, QRCodeGenerationService>()
                .BuildServiceProvider();

            // Resolve services
            var menuService = serviceProvider.GetRequiredService<IMenuService>();
            var testModeService = serviceProvider.GetRequiredService<ITestModeService>();

            // Start the menu
            menuService.StartMenu();
        }
    }
}
