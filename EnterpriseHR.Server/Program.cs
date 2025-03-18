using System.Reflection;
using AutoMapper;
using EnterpriseHR.Application;
using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Application.Contracts.Department;
using EnterpriseHR.Application.Contracts.Employee;
using EnterpriseHR.Application.Services;
using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;
using EnterpriseHR.Domain.Services.InMemory;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AirlineBooking API",
        Version = "v1",
        Description = "API для кадров предприятия"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath, true);
});

// Настройка AutoMapper
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Регистрация репозиториев
builder.Services.AddSingleton<IRepository<Employee, int>, EmployeeInMemoryRepository>();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeInMemoryRepository>();

// Добавьте регистрацию для DepartmentRepository
builder.Services.AddSingleton<IRepository<Department, int>, DepartmentInMemoryRepository>();

// Регистрация сервисов
builder.Services.AddScoped<ICrudService<EmployeeDto, EmployeeCreateUpdateDto, int>, EmployeeCrudService>();
builder.Services.AddScoped<ICrudService<DepartmentDto, DepartmentCreateUpdateDto, int>, DepartmentCrudService>();
builder.Services.AddScoped<IAnalyticsService, EmployeeCrudService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();