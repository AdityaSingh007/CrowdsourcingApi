using DemoApi.EfCore;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Repository
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly DatabaseContext databaseContext;

        public EmployeeManager(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<int> AddEmployee(Employee employee)
        {
            this.databaseContext.employees.Add(employee);
            await this.databaseContext.SaveChangesAsync();
            return employee.EmployeeId;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var employeeToDelete = this.databaseContext.employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            this.databaseContext.employees.Remove(employeeToDelete);
            var opertionStatus = await this.databaseContext.SaveChangesAsync();
            return opertionStatus > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await this.databaseContext.employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return this.databaseContext.employees.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            this.databaseContext.Entry(employee).State = EntityState.Modified;
            this.databaseContext.SaveChanges();
            return await GetEmployeeById(employee.EmployeeId);
        }
    }
}
