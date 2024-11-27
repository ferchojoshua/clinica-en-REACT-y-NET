using Clinica.Application.UseCase.Commons.Behavior;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Clinica.Application.UseCase.Extension
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjectionApplication( this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
