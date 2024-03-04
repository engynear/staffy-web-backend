using Dapper;
using Microsoft.Extensions.Options;
using Staffy.Dal.Entitites;
using Staffy.Dal.Repositories.Interfaces;
using Staffy.Dal.Settings;

namespace Staffy.Dal.Repositories;

public class EmployeeRepository : PgRepository, IEmployeeRepository
{
    public EmployeeRepository(
        IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<EmployeeEntity?> GetById(long id)
    {
        const string sqlQuery = @"
SELECT e.id as Id
     , e.name as Name
     , e.avatar_url as AvatarUrl
FROM employees e
WHERE e.id = @Id
";
        await using var connection = await GetConnection();
        var employee = await connection.QueryFirstOrDefaultAsync<EmployeeEntity>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Id = id
                }));
        return employee;
    }

    public async Task<IEnumerable<EmployeeEntity>> GetAll()
    {
        const string sqlQuery = @"
SELECT e.id as Id
     , e.name as Name
     , e.avatar_url as AvatarUrl
FROM employees e
";
        await using var connection = await GetConnection();
        var employees = await connection.QueryAsync<EmployeeEntity>(sqlQuery);
        return employees;
    }

    public async Task<long> Create(EmployeeEntity employee)
    {
        const string sqlQuery = @"
INSERT INTO employees (name, avatar_url)
VALUES (@Name, @AvatarUrl)
";
        await using var connection = await GetConnection();
        var id = await connection.ExecuteScalarAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Name = employee.Name,
                    AvatarUrl = employee.AvatarUrl
                }));
        return id;
    }

    public async Task Delete(long id)
    {
        const string sqlQuery = @"
DELETE FROM employees
WHERE id = @Id
";
        await using var connection = await GetConnection();
        await connection.ExecuteAsync(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Id = id
                }));
    }
}