using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Application.Contracts.Department;

namespace EnterpriseHR.Server.Controllers;

/// <summary>
///     Контроллер для CRUD-операций над отделами.
/// </summary>
/// <param name="crudService">CRUD-служба.</param>
public class DepartmentController(ICrudService<DepartmentDto, DepartmentCreateUpdateDto, int> crudService)
    : CrudControllerBase<DepartmentDto, DepartmentCreateUpdateDto, int>(crudService);