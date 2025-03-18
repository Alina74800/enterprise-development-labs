using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Льготные путевки, полученные сотрудником.
///     Этот класс представляет информацию о льготах, которые сотрудник получил от профсоюза.
/// </summary>
public class UnionBenefit
{
    /// <summary>
    ///     Уникальный идентификатор записи о льготе.
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор членства в профсоюзе, связанного с этой льготой.
    /// </summary>
    public int UnionMembershipId { get; set; }

    /// <summary>
    ///     Связанный объект членства в профсоюзе.
    /// </summary>
    public virtual UnionMembership? UnionMembership { get; set; }

    /// <summary>
    ///     Дата получения льготы.
    /// </summary>
    public DateTime BenefitDate { get; set; }

    /// <summary>
    ///     Тип льготы (например, "путевка", "скидка" и т.д.).
    /// </summary>
    public string? BenefitType { get; set; }
}