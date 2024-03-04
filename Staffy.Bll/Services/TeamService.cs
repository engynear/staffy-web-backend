using Microsoft.AspNetCore.Http.HttpResults;
using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using Staffy.Dal.Entitites;
using Staffy.Dal.Repositories;
using Staffy.Dal.Repositories.Interfaces;

namespace Staffy.Bll.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _repository;

    public TeamService(ITeamRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        var teams = await _repository.GetAll();
        return teams.Select(t => new Team { 
            Id = t.Id,
            Name = t.Name,
            Description = t.Description,
            CreatedAt = t.CreatedAt,
            ImageUrl = t.ImageUrl
        });
    }

    public async Task<Team?> GetTeamByIdAsync(long id)
    {
        var team = await _repository.GetById(id);
        if (team == null)
            return null;

        return await Task.FromResult(new Team { 
            Id = team.Id,
            Name = team.Name,
            Description = team.Description,
            CreatedAt = team.CreatedAt,
            ImageUrl = team.ImageUrl
        });
    }

    public async Task<long> AddTeamAsync(Team team)
    {
        var id = await _repository.Create(new TeamEntity
        {
            Name = team.Name,
            Description = team.Description,
            CreatedAt = team.CreatedAt,
            ImageUrl = team.ImageUrl
        });
        return id;
    }

    public Task<Team?> UpdateTeamAsync(long id, Team team)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTeamAsync(long id)
    {
        await _repository.Delete(id);
    }

    public async Task AddEmployeeToTeamAsync(long teamId, long employeeId)
    {
        await _repository.AddEmployyee(teamId, employeeId);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesFromTeamAsync(long teamId)
    {
        var employees = await _repository.GetEmployees(teamId);
        return employees.Select(e => new Employee
        {
            Id = e.Id,
            Name = e.Name,
            AvatarUrl = e.AvatarUrl
        });
    }
}