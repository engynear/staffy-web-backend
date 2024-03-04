using Staffy.Dal.Entitites;

namespace Staffy.Dal.Repositories.Interfaces;
public interface ITeamRepository
{
    Task<TeamEntity?> GetById(long id);
    Task<IEnumerable<TeamEntity>> GetAll();
    Task<long> Create(TeamEntity team);
    Task Delete(long id);
    
    Task AddEmployyee(long teamId, long memberId);
    Task<IEnumerable<EmployeeEntity>> GetEmployees(long teamId);
}