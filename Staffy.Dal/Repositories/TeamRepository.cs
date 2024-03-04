using Dapper;
using Microsoft.Extensions.Options;
using Staffy.Dal.Entitites;
using Staffy.Dal.Repositories.Interfaces;
using Staffy.Dal.Settings;

namespace Staffy.Dal.Repositories;

public class TeamRepository : PgRepository, ITeamRepository
{
    public TeamRepository(
        IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }
    
    public async Task<TeamEntity?> GetById(long id)
    {
        const string sqlQuery = @"
SELECT t.id as Id
     , t.name as Name
     , t.description as Description
     , t.created_at as CreatedAt
     , t.image_url as ImageUrl
FROM teams t
WHERE t.id = @Id
";
        await using var connection = await GetConnection();
        var team = await connection.QueryFirstOrDefaultAsync<TeamEntity>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Id = id
                }));
        return team;
    }

    public async Task<IEnumerable<TeamEntity>> GetAll()
    {
        const string sqlQuery = @"
SELECT t.id as Id
     , t.name as Name
     , t.description as Description
     , t.created_at as CreatedAt
     , t.image_url as ImageUrl
FROM teams t
";
        await using var connection = await GetConnection();
        var teams = await connection.QueryAsync<TeamEntity>(sqlQuery);
        return teams;
    }

    public async Task<long> Create(TeamEntity team)
    {
        const string sqlQuery = @"
INSERT INTO teams (name, description, created_at, image_url)
VALUES (@Name, @Description, @CreatedAt, @ImageUrl)
";
        await using var connection = await GetConnection();
        var id = await connection.ExecuteScalarAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    team.Name,
                    team.Description,
                    team.CreatedAt,
                    team.ImageUrl
                }));
        return id;
    }

    public async Task Delete(long id)
    {
        const string sqlQuery = @"
DELETE FROM teams
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

    public async Task AddEmployyee(long teamId, long memberId)
    {
        const string sqlQuery = @"
INSERT INTO team_employees (team_id, employee_id, joined_at)
VALUES (@TeamId, @MemberId, @JoinedAt)
";
        await using var connection = await GetConnection();
        await connection.ExecuteAsync(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    TeamId = teamId,
                    MemberId = memberId,
                    JoinedAt = DateTimeOffset.UtcNow
                }));
    }
    
    public async Task<IEnumerable<EmployeeEntity>> GetEmployees(long teamId)
    {
        const string sqlQuery = @"
SELECT e.id as Id
     , e.name as Name
     , e.avatar_url as AvatarUrl
FROM employees e
JOIN team_employees te ON e.id = te.employee_id
WHERE te.team_id = @TeamId
";
        await using var connection = await GetConnection();
        var employees = await connection.QueryAsync<EmployeeEntity>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    TeamId = teamId
                }));
        return employees;
    }

    public async Task RemoveEmployee(long teamId, long memberId)
    {
        throw new NotImplementedException();
    }
}