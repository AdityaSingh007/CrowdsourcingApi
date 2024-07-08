using SampleMinimalApi.EndpointHandlers;

namespace SampleMinimalApi.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterEmployeeEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var employeeEndpoints = endpointRouteBuilder.MapGroup("/api/employee");
            employeeEndpoints.MapGet("", EmployeeHandlers.GetEmployees);
            employeeEndpoints.MapGet("/GetEmployeeWithManagers", EmployeeHandlers.GetEmployees);
            employeeEndpoints.MapGet("/{employeeId:int}", EmployeeHandlers.GetEmployeeById)
                             .WithName("GetEmployeeById");
            employeeEndpoints.MapPost("", EmployeeHandlers.AddEmployee);
            employeeEndpoints.MapPut("", EmployeeHandlers.UpdateEmployee);
            employeeEndpoints.MapDelete("", EmployeeHandlers.DeleteEmployee);
        }

        public static void RegisterMessageQueueEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var messageQueueEndpoints = endpointRouteBuilder.MapGroup("/api/Message");
            messageQueueEndpoints.MapPost("", MessageQueueHandler.AddMessage);
           
        }
    }
}
