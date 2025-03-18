using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Application.Contracts.Employee;

namespace EnterpriseHR.Server.Controllers;

/// <summary>
///     Контроллер для CRUD-операций над сотрудниками.
/// </summary>
/// <param name="crudService">CRUD-служба.</param>
public class EmployeeController(ICrudService<EmployeeDto, EmployeeCreateUpdateDto, int> crudService)
    : CrudControllerBase<EmployeeDto, EmployeeCreateUpdateDto, int>(crudService);