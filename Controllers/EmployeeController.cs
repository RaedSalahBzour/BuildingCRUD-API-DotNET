using BuildingCRUD.Data;
using BuildingCRUD.Models.Entities;
using BuildingCRUD.Modles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public EmployeesController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {

            return Ok(_dbContext.Employees.ToList());
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            //var employee =_dbContext.Employees.Where(emp => emp.Id == id);
            var employee = _dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Email = addEmployeeDto.Email,
                Name = addEmployeeDto.Name,
                Salary = addEmployeeDto.Salary,
                Phone = addEmployeeDto.Phone,
            };

            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.Email = updateEmployeeDto.Email;
            employee.Name = updateEmployeeDto.Name;
            employee.Salary = updateEmployeeDto.Salary;
            employee.Phone = updateEmployeeDto.Phone;
            _dbContext.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return Ok();
        }



    }
}
