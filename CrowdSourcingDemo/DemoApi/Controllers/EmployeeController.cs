using DemoApi.EfCore;
using DemoApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await this.employeeManager.GetAllEmployee();

                return Ok(employees.Select(x => new EmployeeDto()
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Department = x.Department,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error occured");
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await this.employeeManager.GetEmployeeById(employeeId);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error occured");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployee(Employee employee)
        {
            try
            {
                await this.employeeManager.AddEmployee(employee);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error occured");
            }
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int employeeId, Employee employee)
        {
            try
            {
                employee.EmployeeId = employeeId;
                return Ok(await this.employeeManager.UpdateEmployee(employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error occured");
            }
        }

        [HttpGet("GetAllEmployeesWithManagers", Name = "GetAllEmployeesWithManagers")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesWithManagers()
        {
            try
            {
                var employees = await this.employeeManager.GetAllEmployee();

                return Ok(employees.Select(x => new EmployeeDto()
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Department = x.Department,
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error occured");
            }
        }
    }
}
