using System.ComponentModel.DataAnnotations;

namespace EnterpriseHR.Domain.Model;

/// <summary>
///     Сотрудник предприятия
/// </summary>
public class Employee
{
    /// <summary>
    ///     Регистрационный номер сотрудника
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    ///     Фамилия сотрудника
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Имя сотрудника
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Отчество сотрудника
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Дата рождения сотрудника
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    ///     Пол сотрудника
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    ///     Дата поступления на работу
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    ///     Цех, в котором работает сотрудник
    /// </summary>
    public string? Workshop { get; set; }

    /// <summary>
    ///     Отдел, в котором работает сотрудник
    /// </summary>
    public string? Department { get; set; }

    /// <summary>
    ///     Занимаемая должность
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    ///     Домашний адрес сотрудника
    /// </summary>
    public string? HomeAddress { get; set; }

    /// <summary>
    ///     Рабочий телефон
    /// </summary>
    public string? WorkPhone { get; set; }

    /// <summary>
    ///     Домашний телефон
    /// </summary>
    public string? HomePhone { get; set; }

    /// <summary>
    ///     Семейное положение
    /// </summary>
    public string? MaritalStatus { get; set; }

    /// <summary>
    ///     Число человек в семье
    /// </summary>
    public int? FamilyMembersCount { get; set; }

    /// <summary>
    ///     Число детей
    /// </summary>
    public int? ChildrenCount { get; set; }

    /// <summary>
    ///     Список отделов, в которых числится сотрудник
    /// </summary>
    public virtual List<EmployeeDepartment>? EmployeeDepartments { get; set; } = [];

    /// <summary>
    ///     Архив данных о трудовой деятельности сотрудника
    /// </summary>
    public virtual List<EmploymentHistory>? EmploymentHistory { get; set; } = [];

    /// <summary>
    ///     Информация о членстве в профсоюзе
    /// </summary>
    public virtual UnionMembership? UnionMembership { get; set; }

    /// <summary>
    ///     Перегрузка метода, возвращающего строковое представление объекта.
    ///     Возвращает ФИО сотрудника.
    /// </summary>
    /// <returns>ФИО сотрудника</returns>
    public override string ToString()
    {
        return string.IsNullOrEmpty(Patronymic)
            ? $"{FirstName} {LastName}"
            : $"{LastName} {FirstName} {Patronymic}";
    }
}

/// <summary>
///     Связь сотрудника с отделом
/// </summary>
public class EmployeeDepartment
{
    /// <summary>
    ///     Уникальный идентификатор связи
    /// </summary>
    [Key] 
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Идентификатор отдела
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    ///     Связанный объект отдела
    /// </summary>
    public virtual Department? Department { get; set; }
}

/// <summary>
///     Архив данных о трудовой деятельности сотрудника
/// </summary>
public class EmploymentHistory
{
    /// <summary>
    ///     Уникальный идентификатор записи
    /// </summary>
    [Key] 
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Дата поступления на работу
    /// </summary>
    public DateTime HireDate { get; set; }

    /// <summary>
    ///     Дата увольнения (если применимо)
    /// </summary>
    public DateTime? TerminationDate { get; set; }

    /// <summary>
    ///     Занимаемая должность
    /// </summary>
    public string? Position { get; set; }
}

/// <summary>
///     Информация о членстве в профсоюзе
/// </summary>
public class UnionMembership
{
    /// <summary>
    ///     Уникальный идентификатор записи
    /// </summary>
    [Key] 
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор сотрудника
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    ///     Связанный объект сотрудника
    /// </summary>
    public virtual Employee? Employee { get; set; }

    /// <summary>
    ///     Является ли сотрудник членом профсоюза
    /// </summary>
    public bool IsMember { get; set; }

    /// <summary>
    ///     Список льгот, полученных сотрудником от профсоюза
    /// </summary>
    public virtual List<UnionBenefit>? UnionBenefits { get; set; } = [];
}

/// <summary>
///     Льготные путевки, полученные сотрудником
/// </summary>
public class UnionBenefit
{
    /// <summary>
    ///     Уникальный идентификатор записи
    /// </summary>
    [Key] 
    public required int Id { get; set; }

    /// <summary>
    ///     Идентификатор членства в профсоюзе
    /// </summary>
    public int UnionMembershipId { get; set; }

    /// <summary>
    ///     Связанный объект членства в профсоюзе
    /// </summary>
    public virtual UnionMembership? UnionMembership { get; set; }

    /// <summary>
    ///     Дата получения льготы
    /// </summary>
    public DateTime BenefitDate { get; set; }

    /// <summary>
    ///     Тип льготы
    /// </summary>
    public string? BenefitType { get; set; }
}