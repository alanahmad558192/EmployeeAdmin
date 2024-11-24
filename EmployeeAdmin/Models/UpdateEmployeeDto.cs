namespace EmployeeAdmin.Models
{
    /// <summary>
    /// Data Transfer Object (DTO) used to update an employee's details.
    /// </summary>
    public class UpdateEmployeeDto
    {
        /// <summary>
        /// The updated name of the employee.
        /// This property is required and cannot be null or empty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The updated email address of the employee.
        /// This property is required and must be a valid email format.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// The updated phone number of the employee.
        /// This property is optional and can be null.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// The updated salary of the employee.
        /// This property is required and represents the employee's monthly or annual compensation.
        /// </summary>
        public decimal Salary { get; set; }
    }
}
