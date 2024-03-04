using Staffy.Dal.Entitites;

namespace Staffy.Dal.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<EmployeeEntity?> GetById(long id);
    Task<IEnumerable<EmployeeEntity>> GetAll();
    Task<long> Create(EmployeeEntity employee);
    Task Delete(long id);
}