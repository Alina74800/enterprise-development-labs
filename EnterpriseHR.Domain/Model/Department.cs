using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Отдел предприятия
/// </summary>
public class Department
{
    /// <summary>
    ///     Идентификатор отдела
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Название отдела
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     Список сотрудников, связанных с отделом
    /// </summary>
    public virtual List<EmployeeDepartment>? EmployeeDepartments { get; set; } = [];

    /// <summary>
    ///     Список сотрудников
    /// </summary>
    public virtual List<Employee>? Employees { get; set; }

    /// <summary>
    ///     Перегрузка метода, возвращающего строковое представление объекта
    /// </summary>
    /// <returns>Название отдела</returns>
    public override string ToString()
    {
        return Name ?? "<Без названия>";
    }
}