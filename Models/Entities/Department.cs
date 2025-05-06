namespace EmployeeAdminPortal.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } required

        public string? Description
        { get; set; }
    }
}
