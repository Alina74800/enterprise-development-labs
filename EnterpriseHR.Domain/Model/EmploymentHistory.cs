using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Архив данных о трудовой деятельности сотрудника.
///     Этот класс представляет историю работы сотрудника, включая даты приема на работу, увольнения и занимаемые
///     должности.
/// </summary>
public class EmploymentHistory
{
    /// <summary>
    ///     Уникальный идентификатор записи в архиве трудовой деятельности.
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника, связанного с этой записью.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника, чья трудовая деятельность описывается.
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Дата поступления сотрудника на работу.
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    ///     Дата увольнения сотрудника (если применимо).
    ///     Значение может быть null, если сотрудник все еще работает.
    /// </summary>
    public DateTime? TerminationDate { get; set; }

    /// <summary>
    ///     Должность, которую сотрудник занимал в период работы.
    /// </summary>
    public string? Position { get; set; }
}