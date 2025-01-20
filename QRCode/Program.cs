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
                .AddSingleton<IMenuService, MenuService>()
                .AddSingleton<ITestModeService, TestModeService>()
                .BuildServiceProvider();

            var menuService = serviceProvider.GetRequiredService<IMenuService>();
            menuService.StartMenu();
        }
    }
}
