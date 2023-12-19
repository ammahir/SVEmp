using Microsoft.AspNetCore.Mvc;
using SmartVision.Entities;
using SmartVision.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartVAPI.BLL.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee em;

        public EmployeeController(IEmployee emp)
        {
            em = emp;
        }

        // GET: api/EmployeeController
        [HttpGet]
        public IEnumerable<Employee> Get(string? name)
        {
            List<Employee> employeeList = em.GetAllEmployee(name);

            return employeeList;
        }

 
        // GET api/EmployeeController/5
        [HttpGet("{EmployeeId}")]
        public Employee Get(int EmployeeId)
        {
            Employee employee = em.GetEmployee(EmployeeId);

            return employee;
        }

        // POST api/EmployeeController
       
      
        [HttpPost]
        public async Task<int> Save([FromBody] Employee employee,int action)
        {
            int a = await em.SaveEmployee(employee, action);
            return a;

        }
        [HttpDelete]       
        public int Delete(int EmployeeId)
        {
            int a = em.DeleteEmployee(EmployeeId);
            return a;

        }

    }
}
