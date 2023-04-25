using AutoMapper;
using CoreDemo.Data;
using CoreDemo.Dto;
using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly CoreDemoDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(CoreDemoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDto employeePayLoad)
        {
            var newEmployee = _mapper.Map<Employee>(employeePayLoad);
            await _context.employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return Created($"/{newEmployee.Id}", newEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditEmployee(int id, EmployeeDto employeeToUpdate)
        {
            Employee? employees = await _context.employees.FindAsync(id);
            if (employees == null)
            {
                return BadRequest();
            }
            employees.Name = employeeToUpdate.Name;
            employees.Age = employeeToUpdate.Age;
            employees.Salary = employeeToUpdate.Salary;
            _context.Update(employees);
            await _context.SaveChangesAsync();
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

}

