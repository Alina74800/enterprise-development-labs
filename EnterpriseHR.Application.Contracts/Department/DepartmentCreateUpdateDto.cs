namespace EnterpriseHR.Application.Contracts.Department;

/// <summary>
///     DTO для создания или изменения отдела.
/// </summary>
/// <param name="Name">Название отдела.</param>
/// <param name="Description">Описание отдела.</param>
/// <param name="ManagerId">Идентификатор руководителя отдела.</param>
public record DepartmentCreateUpdateDto(
    string? Name,
    string? Description,
    int? ManagerId);