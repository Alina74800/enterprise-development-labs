using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services;

/// <summary>
///     Интерфейс репозитория для работы с сотрудниками, расширяющий базовый функционал.
/// </summary>
public interface IEmployeeRepository : IRepository<Employee, int>
{
    /// <summary>
    ///     Получает список сотрудников, работающих в указанном отделе.
    /// </summary>
    /// <param name="department">Название отдела.</param>
    /// <returns>Список сотрудников, работающих в отделе.</returns>
    IList<Employee> GetEmployeesByDepartment(string department);

    /// <summary>
    ///     Получает список сотрудников, работающих в нескольких отделах, отсортированных по ФИО.
    /// </summary>
    /// <returns>Список сотрудников, работающих в нескольких отделах.</returns>
    IList<Employee> GetEmployeesInMultipleDepartments();

    /// <summary>
    ///     Получает архив уволенных сотрудников, включая их регистрационный номер, ФИО, дату рождения, цех, отдел и должность.
    /// </summary>
    /// <returns>Список данных об уволенных сотрудниках.</returns>
    IList<Tuple<int, string, DateTime, string, string, string>> GetTerminationArchive();

    /// <summary>
    ///     Вычисляет средний возраст сотрудников в каждом отделе.
    /// </summary>
    /// <returns>Словарь, где ключ — название отдела, а значение — средний возраст сотрудников.</returns>
    IDictionary<string, double> GetAverageAgeByDepartment();

    /// <summary>
    ///     Получает сведения о сотрудниках, которые получали льготные профсоюзные путевки в прошлом году.
    /// </summary>
    /// <returns>Список данных о сотрудниках и видах полученных путевок.</returns>
    IList<Tuple<int, string, string>> GetEmployeesWithUnionBenefitsLastYear();

    /// <summary>
    ///     Получает топ-5 сотрудников с наибольшим стажем работы на предприятии.
    /// </summary>
    /// <returns>Список сотрудников с наибольшим стажем.</returns>
    IList<Employee> GetTop5EmployeesBySeniority();
}