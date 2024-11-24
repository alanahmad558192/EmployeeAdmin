namespace EmployeeAdmin.Models.Entities
{
    /// <summary>
    /// Entity class representing an Employee in the database.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Unique identifier for the employee.
        /// Automatically generated as a GUID (Globally Unique Identifier).
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Full name of the employee.
        /// This property is required and cannot be null or empty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Email address of the employee.
        /// This property is required and must be unique and valid.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Contact phone number of the employee.
        /// This property is optional and can be null.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Salary of the employee.
        /// This property represents the employee's monthly or annual compensation.
        /// </summary>
        public decimal Salary { get; set; }
    }
}
