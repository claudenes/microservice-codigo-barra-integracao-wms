using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository;
using Domain.Interface.Repository;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ICentralRepository), typeof(CentralRepository));
            serviceCollection.AddScoped(typeof(IUnitOfWorkCentral), typeof(UnitOfWork));
        }
    }
}
