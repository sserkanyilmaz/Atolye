using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Atolye.Application
{
	public static class ServiceRegistration
	{
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        }
    }
}

