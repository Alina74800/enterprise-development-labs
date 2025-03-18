using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Связь сотрудника с отделом.
///     Этот класс представляет связь между сотрудником и отделом,
///     в котором он работает или числится.
/// </summary>
public class EmployeeDepartment
{
    /// <summary>
    ///     Уникальный идентификатор связи между сотрудником и отделом.
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника, связанного с этой записью.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника, который числится в отделе.
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Идентификатор отдела, связанного с этой записью.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    ///     Связанный объект отдела, в котором числится сотрудник.
    /// </summary>
    public virtual Department? Department { get; set; }
}