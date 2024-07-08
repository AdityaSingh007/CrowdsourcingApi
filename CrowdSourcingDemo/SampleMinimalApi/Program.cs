using Microsoft.EntityFrameworkCore;
using SampleMinimalApi.EfCore;
using SampleMinimalApi.Extensions;
using SampleMinimalApi.HostedServices;
using SampleMinimalApi.Interface;
using SampleMinimalApi.Repository;
using SampleMinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(@"Data Source=.\Data\Employees.db"));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<IMessageQueueHandler, MessageQueueHandler>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHostedService<MessageProcessor>();
//
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.RegisterEmployeeEndpoints();
app.RegisterMessageQueueEndpoints();

if (!Directory.Exists("Data"))
{
    Directory.CreateDirectory("Data");
}
// recreate & migrate the database on each run, for demo purposes
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();