using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Информация о членстве сотрудника в профсоюзе.
///     Этот класс представляет данные о том, является ли сотрудник членом профсоюза,
///     а также список связанных льгот, полученных от профсоюза.
/// </summary>
public class UnionMembership
{
    /// <summary>
    ///     Уникальный идентификатор записи о членстве в профсоюзе.
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника, связанного с этой записью.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника, чье членство в профсоюзе описывается.
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Флаг, указывающий, является ли сотрудник членом профсоюза.
    ///     Значение true означает, что сотрудник является членом профсоюза,
    ///     false — не является.
    /// </summary>
    public bool IsMember { get; set; }

    /// <summary>
    ///     Список льгот, полученных сотрудником от профсоюза.
    ///     Если сотрудник не получил льгот, список может быть пустым.
    /// </summary>
    public virtual List<UnionBenefit>? UnionBenefits { get; set; } = [];
}