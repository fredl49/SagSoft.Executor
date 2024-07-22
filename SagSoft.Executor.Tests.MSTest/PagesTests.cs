using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SagSoft.Executor.Contracts.Services;
using SagSoft.Executor.Core.Contracts.Services;
using SagSoft.Executor.Core.Services;
using SagSoft.Executor.Models;
using SagSoft.Executor.Services;
using SagSoft.Executor.ViewModels;
using SagSoft.Executor.Views;

namespace SagSoft.Executor.Tests.MSTest;

[TestClass]
public class PagesTests
{
    private readonly IHost _host;

    public PagesTests()
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => c.SetBasePath(appLocation))
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Core Services
        services.AddSingleton<IFileService, FileService>();

        // Services
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        services.AddTransient<InstallerViewModel>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    // TODO: Add tests for functionality you add to InstallerViewModel.
    [TestMethod]
    public void TestInstallerViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(InstallerViewModel));
        Assert.IsNotNull(vm);
    }

    [TestMethod]
    public void TestGetInstallerPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(InstallerViewModel).FullName);
            Assert.AreEqual(typeof(InstallerPage), pageType);
        }
        else
        {
            Assert.Fail($"Can't resolve {nameof(IPageService)}");
        }
    }
}
