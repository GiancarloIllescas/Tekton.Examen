using Microsoft.Extensions.DependencyInjection;
using Tekton.Examen.Application.Interface.Cache;
using Tekton.Examen.Application.Interface.Persistence;
using Tekton.Examen.Cross.Common;
using Tekton.Examen.Persistence.Data;
using Tekton.Examen.Persistence.Repositories;
using Tekton.Examen.Persistence.Cache;
using Tekton.Examen.Application.Interface.Services;
using Tekton.Examen.Persistence.Services;

namespace Tekton.Examen.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStatusCache, ProductStatusCache>();
            

            return services;
        }

    }
}
