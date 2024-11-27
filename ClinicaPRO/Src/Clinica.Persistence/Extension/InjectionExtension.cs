using Microsoft.Extensions.DependencyInjection;
using Clinical.Infraestructure.Context;
using Clinica.Persistence.Repositories;
using Clinica.Domain.Entities;
using Clinica.Application.Interface.Interfaces;

namespace Clinica.Persistence.Extension
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnalisysRepository, AnalisysRepository>();
            return services;
        }
    }
}
    