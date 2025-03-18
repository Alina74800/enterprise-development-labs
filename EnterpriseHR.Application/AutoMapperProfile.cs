using AutoMapper;
using EnterpriseHR.Application.Contracts.Department;
using EnterpriseHR.Application.Contracts.Employee;
using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Application;

/// <summary>
///     Класс для настройки AutoMapper.
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Маппинг для сущности Employee
        CreateMap<Employee, EmployeeDto>();
        CreateMap<EmployeeCreateUpdateDto, Employee>();

        // Маппинг для сущности Department
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentCreateUpdateDto, Department>();
    }
}