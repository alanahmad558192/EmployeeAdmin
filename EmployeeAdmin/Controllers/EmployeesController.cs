using EmployeeAdmin.Data;
using EmployeeAdmin.Models;
using EmployeeAdmin.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // For List
using System.Linq; // For LINQ methods
using System.Threading.Tasks; // For asynchronous methods

namespace EmployeeAdmin.Controllers
{
    /// <summary>
    /// API controller for managing employees.
    /// Provides endpoints to perform CRUD operations: Create, Read, Update, Delete.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        /// <summary>
        /// Constructor to inject the database context.
        /// </summary>
        /// <param name="dbContext">The application's database context.</param>
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Gets all employees from the database.
        /// </summary>
        /// <returns>List of all employees.</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            // Retrieve all employees from the database and convert to a list
            List<Employee> employees = dbContext.Employees.ToList();
            return Ok(employees); // Return HTTP 200 with the list of employees
        }

        /// <summary>
        /// Gets a single employee by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the employee.</param>
        /// <returns>The employee with the specified ID or 404 if not found.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            // Find the employee by their ID
            Employee employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                // Return HTTP 404 if the employee is not found
                return NotFound();
            }

            // Return HTTP 200 with the employee data
            return Ok(employee);
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="addEmployeeDto">Data for the new employee.</param>
        /// <returns>The created employee.</returns>
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            // Create a new Employee entity from the DTO
            Employee employeeEntity = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            // Add the employee to the database and save changes
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            // Return HTTP 201 Created with the created employee
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeEntity.Id }, employeeEntity);
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        /// <param name="id">The unique ID of the employee to update.</param>
        /// <param name="updateEmployeeDto">Updated data for the employee.</param>
        /// <returns>The updated employee or 404 if not found.</returns>
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            // Find the existing employee by ID
            Employee employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                // Return HTTP 404 if the employee is not found
                return NotFound();
            }

            // Update the employee's properties with the new data
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            // Save the changes to the database
            dbContext.SaveChanges();

            // Return HTTP 200 with the updated employee
            return Ok(employee);
        }

        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="id">The unique ID of the employee to delete.</param>
        /// <returns>200 OK if successful, or 404 if the employee does not exist.</returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            // Find the employee by their ID
            Employee employee = dbContext.Employees.Find(id);

            if (employee is null)
            {
                // Return HTTP 404 if the employee is not found
                return NotFound();
            }

            // Remove the employee from the database and save changes
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            // Return HTTP 200 indicating the employee was deleted
            return Ok();
        }
    }
}
