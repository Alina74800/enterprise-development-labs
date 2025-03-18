using AutoMapper;
using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Application.Contracts.Employee;
using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;

namespace EnterpriseHR.Application.Services;

/// <summary>
///     Служба слоя приложения для манипуляции над сотрудниками.
/// </summary>
/// <param name="repository">Доменная служба для сотрудников.</param>
/// <param name="mapper">Автомаппер.</param>
public class EmployeeCrudService(IEmployeeRepository repository, IMapper mapper)
    : ICrudService<EmployeeDto, EmployeeCreateUpdateDto, int>, IAnalyticsService
{
    /// <summary>
    ///     Получает список сотрудников по указанному отделу.
    /// </summary>
    /// <param name="department">Название отдела.</param>
    /// <returns>Список сотрудников в указанном отделе.</returns>
    public IList<Employee> GetEmployeesByDepartment(string department)
    {
        return repository.GetEmployeesByDepartment(department);
    }

    /// <summary>
    ///     Получает список сотрудников, работающих в нескольких отделах, с сортировкой по ФИО.
    /// </summary>
    /// <returns>Список сотрудников, работающих в нескольких отделах.</returns>
    public IList<Employee> GetEmployeesInMultipleDepartments()
    {
        return repository.GetEmployeesInMultipleDepartments();
    }

    /// <summary>
    ///     Получает архив уволенных сотрудников.
    /// </summary>
    /// <returns>Список данных об уволенных сотрудниках.</returns>
    public IList<Tuple<int, string, DateTime, string, string, string>> GetTerminationArchive()
    {
        return repository.GetTerminationArchive();
    }

    /// <summary>
    ///     Вычисляет средний возраст сотрудников в каждом отделе.
    /// </summary>
    /// <returns>Словарь, где ключ — название отдела, а значение — средний возраст сотрудников.</returns>
    public IDictionary<string, double> GetAverageAgeByDepartment()
    {
        return repository.GetAverageAgeByDepartment();
    }

    /// <summary>
    ///     Получает сведения о сотрудниках, которые получали льготные путевки в прошлом году.
    /// </summary>
    /// <returns>Список данных о сотрудниках и видах полученных путевок.</returns>
    public IList<Tuple<int, string, string>> GetEmployeesWithUnionBenefitsLastYear()
    {
        return repository.GetEmployeesWithUnionBenefitsLastYear();
    }

    /// <summary>
    ///     Получает топ-5 сотрудников с наибольшим стажем работы на предприятии.
    /// </summary>
    /// <returns>Список сотрудников с наибольшим стажем.</returns>
    public IList<Employee> GetTop5EmployeesBySeniority()
    {
        return repository.GetTop5EmployeesBySeniority();
    }

    /// <summary>
    ///     Создает нового сотрудника.
    /// </summary>
    /// <param name="newDto">Данные для создания сотрудника.</param>
    /// <returns>True, если сотрудник успешно создан, иначе False.</returns>
    public bool Create(EmployeeCreateUpdateDto newDto)
    {
        Employee? newEmployee = mapper.Map<Employee>(newDto);
        newEmployee.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newEmployee);
        return result;
    }

    /// <summary>
    ///     Удаляет сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника.</param>
    /// <returns>True, если сотрудник успешно удален, иначе False.</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    ///     Получает сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника.</param>
    /// <returns>Данные сотрудника или null, если сотрудник не найден.</returns>
    public EmployeeDto? GetById(int id)
    {
        Employee? employee = repository.Get(id);
        return mapper.Map<EmployeeDto>(employee);
    }

    /// <summary>
    ///     Получает список всех сотрудников.
    /// </summary>
    /// <returns>Список всех сотрудников.</returns>
    public IList<EmployeeDto> GetList()
    {
        return mapper.Map<List<EmployeeDto>>(repository.GetAll());
    }

    /// <summary>
    ///     Обновляет данные сотрудника.
    /// </summary>
    /// <param name="key">Идентификатор сотрудника.</param>
    /// <param name="newDto">Новые данные сотрудника.</param>
    /// <returns>True, если данные успешно обновлены, иначе False.</returns>
    public bool Update(int key, EmployeeCreateUpdateDto newDto)
    {
        Employee? oldEmployee = repository.Get(key);
        Employee? newEmployee = mapper.Map<Employee>(newDto);
        newEmployee.Id = key;
        newEmployee.EmployeeDepartments = oldEmployee?.EmployeeDepartments;
        newEmployee.EmploymentHistory = oldEmployee?.EmploymentHistory;
        newEmployee.UnionMembership = oldEmployee?.UnionMembership;
        var result = repository.Update(newEmployee);
        return result;
    }
}