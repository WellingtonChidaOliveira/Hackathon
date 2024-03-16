using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hackathon.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly);
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
