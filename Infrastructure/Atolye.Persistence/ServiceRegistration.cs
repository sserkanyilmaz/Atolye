using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Configurations;
using Atolye.Persistence.Context;
using Atolye.Persistence.Repositories;
using Atolye.Persistence.Repositories.ActivityLogs;
using Atolye.Persistence.Repositories.ActivityLogs.CareerStuffs;
using Atolye.Persistence.Repositories.CareerStuffs;
using Atolye.Persistence.Repositories.ConsumableInventories;
using Atolye.Persistence.Repositories.Contacts;
using Atolye.Persistence.Repositories.EngineerOfTheMonths;
using Atolye.Persistence.Repositories.FixtureInformations;
using Atolye.Persistence.Repositories.Images;
using Atolye.Persistence.Repositories.Inventories;
using Atolye.Persistence.Repositories.News;
using Atolye.Persistence.Repositories.Projects;
using Atolye.Persistence.Repositories.Reports;
using Atolye.Persistence.Repositories.Sliders;
using Atolye.Persistence.Repositories.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atolye.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            Configuration.Configure(configuration);
            services.AddDbContext<AtolyeDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IQueryRepository<ActivityLog>, ActivityLogQueryRepository>();
            services.AddScoped<ICommandRepository<ActivityLog>, ActivityLogCommandRepository>();

            services.AddScoped<IQueryRepository<CareerStuff>, CareerStuffQueryRepository>();
            services.AddScoped<ICommandRepository<CareerStuff>, CareerStuffCommandRepository>();

            services.AddScoped<IQueryRepository<ConsumableInventory>, ConcumableInventoryQueryRepository>();
            services.AddScoped<ICommandRepository<ConsumableInventory>, ConcumableInventoryCommandRepository>();

            services.AddScoped<IQueryRepository<Contact>, ContactQueryRepository>();
            services.AddScoped<ICommandRepository<Contact>, ContactCommandRepository>();

            services.AddScoped<IQueryRepository<EngineerOfTheMonth>, EngineerOfTheMonthQueryRepository>();
            services.AddScoped<ICommandRepository<EngineerOfTheMonth>, EngineerOfTheMonthCommandRepository>();

            services.AddScoped<IQueryRepository<FixtureInformation>, FixtureInformationQueryRepository>();
            services.AddScoped<ICommandRepository<FixtureInformation>, FixtureInformationCommandRepository>();

            services.AddScoped<IQueryRepository<Image>, ImageQueryRepository>();
            services.AddScoped<ICommandRepository<Image>, ImageCommandRepository>();

            services.AddScoped<IQueryRepository<Inventory>, InventoryQueryRepository>();
            services.AddScoped<ICommandRepository<Inventory>, InventoryCommandRepository>();

            services.AddScoped<IQueryRepository<BaseNew>, NewsQueryRepository>();
            services.AddScoped<ICommandRepository<BaseNew>, NewsCommandRepository>();

            services.AddScoped<IQueryRepository<Project>, ProjectQueryRepository>();
            services.AddScoped<ICommandRepository<Project>, ProjectCommandRepository>();

            services.AddScoped<IQueryRepository<Report>, ReportQueryRepository>();
            services.AddScoped<ICommandRepository<Report>, ReportCommandRepository>();

            services.AddScoped<IQueryRepository<Slider>, SliderQueryRepository>();
            services.AddScoped<ICommandRepository<Slider>, SliderCommandRepository>();

            services.AddScoped<IQueryRepository<Person>, QueryRepository<Person>>();
            services.AddScoped<ICommandRepository<Person>, PersonCommandRepository>();

            services.AddScoped<IQueryRepository<Team>, QueryRepository<Team>>();
            services.AddScoped<ICommandRepository<Team>, TeamCommandRepository>();

        }
    }
}

