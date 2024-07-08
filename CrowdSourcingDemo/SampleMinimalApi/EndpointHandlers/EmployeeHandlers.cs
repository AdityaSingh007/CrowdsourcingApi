using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SampleMinimalApi.EfCore.Entity;
using SampleMinimalApi.Interface;
using SampleMinimalApi.Model;

namespace SampleMinimalApi.EndpointHandlers
{
    public static class EmployeeHandlers
    {
        public static async Task<Ok<IEnumerable<EmployeeDto>>> GetEmployees(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            return TypedResults.Ok(mapper.Map<IEnumerable<EmployeeDto>>(await employeeRepository.GetAllEmployee()));
        }

        public static async Task<Results<NotFound, Ok<EmployeeDto>>> GetEmployeeById(
           IEmployeeRepository employeeRepository,
           IMapper mapper,
           int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeById(employeeId);

            if (employee == null)
                return TypedResults.NotFound();

            return TypedResults.Ok(mapper.Map<EmployeeDto>(employee));
        }

        public static async Task<CreatedAtRoute<EmployeeDto>> AddEmployee(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);
            employee = await employeeRepository.AddEmployee(employee);
            return TypedResults.CreatedAtRoute(mapper.Map<EmployeeDto>(employee), "GetEmployeeById", new
            {
                employeeId = employee.EmployeeId
            });
        }

        public static async Task<Results<NotFound, NoContent>> DeleteEmployee(
            IEmployeeRepository employeeRepository,
            int employeeId)
        {
            try
            {
                await employeeRepository.DeleteEmployee(employeeId);
                return TypedResults.NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return TypedResults.NotFound();
            }
        }

        public static async Task<Results<NotFound, NoContent>> UpdateEmployee(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            EmployeeDto employeeDto)
        {
            var employeeToUpdate = await employeeRepository.GetEmployeeById(employeeDto.EmployeeId);
            if (employeeToUpdate == null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(employeeDto, employeeToUpdate);
            await employeeRepository.UpdateEmployee(employeeToUpdate);
            return TypedResults.NoContent();
        }
    }
}
