using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase

    {

        private readonly ApplicationDbContext dbContext;
        public DepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var allDepartments = dbContext.Departments.ToList();
            return Ok(allDepartments);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDepartmentById(int id)
        {
            var department = dbContext.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }


        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto addDepartmentDto)
        {

            var departmentEntity = new Department()
            {
                Name = addDepartmentDto.Name,
                Description = addDepartmentDto.Description
            };

            //// Check if the department already exists
            //var existingDepartment = dbContext.Departments
            //    .FirstOrDefault(d => d.Name == departmentEntity.Name);

            //if (existingDepartment != null)
            //{
            //    return BadRequest("Department already exists.");
            //}



            dbContext.Departments.Add(departmentEntity);
            dbContext.SaveChanges();
            return Ok(departmentEntity);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            var departmentEntity = dbContext.Departments.Find(id);
            if (departmentEntity == null)
            {
                return NotFound();
            }
            departmentEntity.Name = updateDepartmentDto.Name;
            departmentEntity.Description = updateDepartmentDto.Description;
            dbContext.SaveChanges();
            return Ok(departmentEntity);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteDepartment(int id) {


            var departmentEntity = dbContext.Departments.Find(id);
            if (departmentEntity == null)
            {
                return NotFound();
            }
            dbContext.Departments.Remove(departmentEntity);
            dbContext.SaveChanges();
            return Ok(departmentEntity);
        }
    }
}
