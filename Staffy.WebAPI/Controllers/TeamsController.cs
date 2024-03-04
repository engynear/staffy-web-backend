using Microsoft.AspNetCore.Mvc;
using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using StaffyWebAPI.DTOs;

namespace StaffyWebAPI.Controllers;

[ApiController]
[Route("teams")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeams()
    {
        var teams = await _teamService.GetAllTeamsAsync();
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeam(long id)
    {
        var team = await _teamService.GetTeamByIdAsync(id);
        if (team == null)
            return NotFound();
            
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamDto teamDto)
    {
        var team = new Team { 
            Name = teamDto.Name,
            Description = teamDto.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            ImageUrl = teamDto.ImageUrl
        };
        var id = await _teamService.AddTeamAsync(team);
        
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(long id)
    {
        await _teamService.DeleteTeamAsync(id);
        return NoContent();
    }
    
    [HttpPost("{teamId}/employees/")]
    public async Task<IActionResult> AddEmployeeToTeam(long teamId, long employeeId)
    {
        await _teamService.AddEmployeeToTeamAsync(teamId, employeeId);
        return Ok();
    }
    
    [HttpGet("{id}/employees")]
    public async Task<IActionResult> GetEmployees(long id)
    {
        var employees = await _teamService.GetEmployeesFromTeamAsync(id);
        return Ok(employees);
    }
}