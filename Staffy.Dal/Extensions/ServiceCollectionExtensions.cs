using HomeworkApp.Dal.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staffy.Dal.Repositories;
using Staffy.Dal.Repositories.Interfaces;
using Staffy.Dal.Settings;

namespace Staffy.Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITeamRepository, TeamRepository>();
        serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return serviceCollection;
    }
    
    public static IServiceCollection AddDalInfrastructure(
        this IServiceCollection services, 
        IConfigurationRoot config)
    {
        //read config
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        //configure postrges types
        Postgres.MapCompositeTypes();
        
        //add migrations
        Postgres.AddMigrations(services);
        
        return services;

    }
}