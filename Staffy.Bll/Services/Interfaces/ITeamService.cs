using Staffy.Bll.Models;
using Staffy.Dal.Entitites;

namespace Staffy.Bll.Services.Interfaces;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task<Team?> GetTeamByIdAsync(long id);
    Task<long> AddTeamAsync(Team team);
    Task<Team?> UpdateTeamAsync(long id, Team team);
    Task DeleteTeamAsync(long id);
    
    Task AddEmployeeToTeamAsync(long teamId, long employeeId);
    Task<IEnumerable<Employee>> GetEmployeesFromTeamAsync(long teamId);
}