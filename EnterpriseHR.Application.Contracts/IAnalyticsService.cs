namespace EnterpriseHR.Application.Contracts;

/// <summary>
///     Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения.
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    ///     Получает список сотрудников по указанному отделу.
    /// </summary>
    /// <param name="department">Название отдела.</param>
    /// <returns>Список сотрудников в указанном отделе.</returns>
    IList<Domain.Model.Employee> GetEmployeesByDepartment(string department);

    /// <summary>
    ///     Получает список сотрудников, работающих в нескольких отделах, с сортировкой по ФИО.
    /// </summary>
    /// <returns>Список сотрудников, работающих в нескольких отделах.</returns>
    IList<Domain.Model.Employee> GetEmployeesInMultipleDepartments();

    /// <summary>
    ///     Получает архив уволенных сотрудников, включая их идентификатор, ФИО, дату рождения, цех, отдел и должность.
    /// </summary>
    /// <returns>Список данных об уволенных сотрудниках.</returns>
    IList<Tuple<int, string, DateTime, string, string, string>> GetTerminationArchive();

    /// <summary>
    ///     Вычисляет средний возраст сотрудников в каждом отделе.
    /// </summary>
    /// <returns>Словарь, где ключ — название отдела, а значение — средний возраст сотрудников.</returns>
    IDictionary<string, double> GetAverageAgeByDepartment();

    /// <summary>
    ///     Получает сведения о сотрудниках, которые получали льготные путевки в прошлом году.
    /// </summary>
    /// <returns>Список данных о сотрудниках и видах полученных путевок.</returns>
    IList<Tuple<int, string, string>> GetEmployeesWithUnionBenefitsLastYear();

    /// <summary>
    ///     Получает топ-5 сотрудников с наибольшим стажем работы на предприятии.
    /// </summary>
    /// <returns>Список сотрудников с наибольшим стажем.</returns>
    IList<Domain.Model.Employee> GetTop5EmployeesBySeniority();
}