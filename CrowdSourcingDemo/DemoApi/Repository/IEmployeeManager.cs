using DemoApi.EfCore;

namespace DemoApi.Repository
{
    public interface IEmployeeManager
    {
        Task<int> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int employeeId);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(int employeeId);
    }
}
