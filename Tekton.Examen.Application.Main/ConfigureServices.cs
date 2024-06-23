using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Examen.Application.Features.Product;
using Tekton.Examen.Application.Interface.Features;

namespace Tekton.Examen.Application.Features
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductApplication, ProductApplication>();

            return services;
        }
    }
}
