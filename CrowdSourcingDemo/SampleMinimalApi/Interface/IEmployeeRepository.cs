using SampleMinimalApi.EfCore.Entity;

namespace SampleMinimalApi.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int employeeId);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeById(int employeeId);
    }
}
