using Microsoft.AspNetCore.Mvc;
using Staffy.Bll.Models;
using Staffy.Bll.Services.Interfaces;
using StaffyWebAPI.DTOs;

namespace StaffyWebAPI.Controllers;

[ApiController]
[Route("employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService _employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeesService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(long id)
    {
        var employee = await _employeesService.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound();
            
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeDto employeeDto)
    {
        var employee = new Employee { 
            Name = employeeDto.Name,
            AvatarUrl = employeeDto.AvatarUrl
        };
        var id = await _employeesService.AddEmployeeAsync(employee);
        
        return Ok(id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(long id)
    {
        await _employeesService.DeleteEmployeeAsync(id);
        return NoContent();
    }
}