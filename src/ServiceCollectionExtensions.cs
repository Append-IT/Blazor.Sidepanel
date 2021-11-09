using Microsoft.Extensions.DependencyInjection;
namespace Append.Blazor.Sidepanel;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSidepanel(this IServiceCollection services)
    {
        services.AddScoped<ISidepanelService, SidepanelService>();
        return services;
    }
}
