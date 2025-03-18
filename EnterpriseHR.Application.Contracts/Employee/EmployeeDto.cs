namespace EnterpriseHR.Application.Contracts.Employee;

/// <summary>
///     DTO для просмотра сведений о сотруднике.
/// </summary>
/// <param name="Id">Идентификатор сотрудника.</param>
/// <param name="LastName">Фамилия сотрудника.</param>
/// <param name="FirstName">Имя сотрудника.</param>
/// <param name="Patronymic">Отчество сотрудника.</param>
/// <param name="DateOfBirth">Дата рождения сотрудника.</param>
/// <param name="Gender">Пол сотрудника.</param>
/// <param name="HireDate">Дата приема на работу.</param>
/// <param name="Workshop">Цех, в котором работает сотрудник.</param>
/// <param name="Department">Отдел, в котором работает сотрудник.</param>
/// <param name="Position">Должность сотрудника.</param>
/// <param name="HomeAddress">Домашний адрес сотрудника.</param>
/// <param name="WorkPhone">Рабочий телефон сотрудника.</param>
/// <param name="HomePhone">Домашний телефон сотрудника.</param>
/// <param name="MaritalStatus">Семейное положение сотрудника.</param>
/// <param name="FamilyMembersCount">Количество членов семьи.</param>
/// <param name="ChildrenCount">Количество детей.</param>
/// <param name="EmploymentHistoryCount">Количество записей в истории трудоустройства.</param>
public record EmployeeDto(
    int Id,
    string? LastName,
    string? FirstName,
    string? Patronymic,
    DateTime? DateOfBirth,
    string? Gender,
    DateTime? HireDate,
    string? Workshop,
    string? Department,
    string? Position,
    string? HomeAddress,
    string? WorkPhone,
    string? HomePhone,
    string? MaritalStatus,
    int? FamilyMembersCount,
    int? ChildrenCount,
    int? EmploymentHistoryCount);