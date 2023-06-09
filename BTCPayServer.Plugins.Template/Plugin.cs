using BTCPayServer.Abstractions.Contracts;
using BTCPayServer.Abstractions.Models;
using BTCPayServer.Abstractions.Services;
using BTCPayServer.Logging;
using BTCPayServer.Plugins.Serilog;
using BTCPayServer.Plugins.Serilog.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BTCPayServer.Plugins.Serilog;

public class Plugin : BaseBTCPayServerPlugin
{
    public override IBTCPayServerPlugin.PluginDependency[] Dependencies { get; } = new[]
    {
        new IBTCPayServerPlugin.PluginDependency { Identifier = nameof(BTCPayServer), Condition = ">=1.8.2" }
    };

    public override void Execute(IServiceCollection services)
    {

        services.AddSingleton<IUIExtension>(new UIExtension("SerilogPluginHeaderNav", "header-nav"));
        services.AddHostedService<ApplicationPartsLogger>();
        services.AddHostedService<PluginRunner>();
        services.AddSingleton<SerilogService>();

    }
}
