using Microsoft.Extensions.DependencyInjection;
using Staffy.Bll.Services;
using Staffy.Bll.Services.Interfaces;
using Staffy.Dal.Repositories;
using Staffy.Dal.Repositories.Interfaces;

namespace Staffy.Bll;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITeamService, TeamService>();
        serviceCollection.AddScoped<IEmployeesService, EmployeesService>();
        return serviceCollection;
    }
}