namespace EmployeeAdmin.Models
{
    /// <summary>
    /// Data Transfer Object (DTO) used for adding a new employee.
    /// </summary>
    public class AddEmployeeDto
    {
        /// <summary>
        /// The name of the new employee.
        /// This property is required and cannot be null or empty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The email address of the new employee.
        /// This property is required and must be a valid email format.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// The phone number of the new employee.
        /// This property is optional and can be null.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// The salary of the new employee.
        /// This property is required and represents the employee's monthly or annual compensation.
        /// </summary>
        public decimal Salary { get; set; }
    }
}
