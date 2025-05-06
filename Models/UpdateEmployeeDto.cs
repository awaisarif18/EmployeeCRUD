namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto
    {

        

        public string Name { get; set; } required

        public string Email { get; set; } required

        public string? Phone { get; set; }

        public decimal Salary { get; set; }

        public int? DepartmentId { get; set; }
    }
}
