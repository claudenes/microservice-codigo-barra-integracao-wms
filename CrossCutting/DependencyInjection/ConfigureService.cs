using Domain.Interface.Service;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IIntegracaoService, IntegracaoService>();
        }
    }
}
