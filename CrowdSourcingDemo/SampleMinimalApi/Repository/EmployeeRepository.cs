using Microsoft.EntityFrameworkCore;
using SampleMinimalApi.EfCore;
using SampleMinimalApi.EfCore.Entity;
using SampleMinimalApi.Interface;

namespace SampleMinimalApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            employee.EmployeeId = 0;
            this.databaseContext.employees.Add(employee);
            await this.databaseContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var employeeToDelete = await this.databaseContext.employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            this.databaseContext.employees.Remove(employeeToDelete ?? throw new ArgumentNullException(nameof(employeeToDelete)));
            var operationStatus = await this.databaseContext.SaveChangesAsync();
            return operationStatus > 0;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await this.databaseContext.employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await this.databaseContext.employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            //this.databaseContext.Entry(employee).State = EntityState.Modified;
            this.databaseContext.SaveChanges();
            return await GetEmployeeById(employee.EmployeeId);
        }
    }
}
