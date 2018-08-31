using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using Livraria.Infra.Data.Context;
using Livraria.Infra.Data.Repository;
using Livraria.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.DI.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IServiceBase<Livro>, ServiceBase<Livro>>();
            services.AddTransient<IServiceBase<Autor>, ServiceBase<Autor>>();
            services.AddTransient<IServiceBase<Editora>, ServiceBase<Editora>>();
            services.AddTransient<IRepositoryBase<Livro>, RepositoryBase<Livro>>();
            services.AddTransient<IRepositoryBase<Autor>, RepositoryBase<Autor>>();
            services.AddTransient<IRepositoryBase<Editora>, RepositoryBase<Editora>>();

            return services;
        }

        public static IServiceCollection AddServiceInfra(this IServiceCollection services)
        {
            services.AddScoped<LivrariaDbContext>();

            return services;
        }
    }
}
