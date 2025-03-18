namespace EnterpriseHR.Application.Contracts.Department;

/// <summary>
///     DTO для просмотра сведений об отделе.
/// </summary>
/// <param name="Id">Идентификатор отдела.</param>
/// <param name="Name">Название отдела.</param>
/// <param name="Description">Описание отдела.</param>
/// <param name="ManagerId">Идентификатор руководителя отдела.</param>
/// <param name="EmployeeCount">Количество сотрудников в отделе.</param>
public record DepartmentDto(
    int Id,
    string? Name,
    string? Description,
    int? ManagerId,
    int? EmployeeCount);