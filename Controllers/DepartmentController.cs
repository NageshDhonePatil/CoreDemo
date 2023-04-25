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
    public class DepartmentController : Controller
    {
        private readonly CoreDemoDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController(CoreDemoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto departmentPayLoad)
        {
            var newDepartment = _mapper.Map<Department>(departmentPayLoad);
            //var newEmployee = _mapper.Map<Employee>(employeePayLoad);
            await _context.departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();
            return Created($"/{newDepartment.Id}", newDepartment);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentsAsync()
        {
            var departments = await _context.departments.ToListAsync();
            return Ok(departments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditDepartment(int id, DepartmentDto departmentToUpdate)
        {
            Department? departments = await _context.departments.FindAsync(id);
            if (departments == null)
            {
                return BadRequest();
            }
            departments.Name = departments.Name;
            //department.Employees= department.Employees;
            _context.Update(departments);
            await _context.SaveChangesAsync();
            return Ok(departments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            var department = await _context.departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
