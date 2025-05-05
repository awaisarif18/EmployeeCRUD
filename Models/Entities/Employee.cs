namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string  Name { get; set; } required
        
        public string Email { get; set; } required

        public string? Phone { get; set; } 

        public decimal Salary { get; set; }
        
   

    }
}
