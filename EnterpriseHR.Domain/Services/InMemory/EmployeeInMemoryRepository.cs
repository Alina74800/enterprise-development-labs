using EnterpriseHR.Domain.Data;
using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Services.InMemory;

/// <summary>
///     Репозиторий для работы с данными сотрудников в памяти
/// </summary>
public class EmployeeInMemoryRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees;

    /// <summary>
    ///     Инициализирует новый экземпляр репозитория и загружает данные из сидера
    /// </summary>
    public EmployeeInMemoryRepository()
    {
        _employees = DataSeeder.Employees;
    }

    /// <summary>
    ///     Добавляет нового сотрудника в коллекцию
    /// </summary>
    /// <param name="entity">Сотрудник для добавления</param>
    /// <returns>True, если сотрудник успешно добавлен, иначе False</returns>
    public bool Add(Employee entity)
    {
        try
        {
            _employees.Add(entity);
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Удаляет сотрудника по его идентификатору
    /// </summary>
    /// <param name="key">Идентификатор сотрудника</param>
    /// <returns>True, если сотрудник успешно удален, иначе False</returns>
    public bool Delete(int key)
    {
        try
        {
            Employee? author = Get(key);
            if (author != null)
            {
                _employees.Remove(author);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Обновляет данные сотрудника
    /// </summary>
    /// <param name="entity">Сотрудник с обновленными данными</param>
    /// <returns>True, если данные успешно обновлены, иначе False</returns>
    public bool Update(Employee entity)
    {
        try
        {
            Delete(entity.Id);
            Add(entity);
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Получает сотрудника по его идентификатору
    /// </summary>
    /// <param name="key">Идентификатор сотрудника</param>
    /// <returns>Найденный сотрудник или null, если сотрудник не найден</returns>
    public Employee? Get(int key)
    {
        return _employees.FirstOrDefault(item => item.Id == key);
    }

    /// <summary>
    ///     Получает список всех сотрудников
    /// </summary>
    /// <returns>Список всех сотрудников</returns>
    public IList<Employee> GetAll()
    {
        return _employees;
    }

    /// <summary>
    ///     Получает список сотрудников по указанному отделу
    /// </summary>
    /// <param name="department">Название отдела</param>
    /// <returns>Список сотрудников в указанном отделе</returns>
    public IList<Employee> GetEmployeesByDepartment(string department)
    {
        return _employees
            .Where(e => e.Department == department)
            .ToList();
    }

    /// <inheritdoc />
    public IList<Employee> GetEmployeesInMultipleDepartments()
    {
        return _employees
            .Where(e => e.EmployeeDepartments?.Count > 1)
            .OrderBy(e => e.LastName)
            .ThenBy(e => e.FirstName)
            .ThenBy(e => e.Patronymic)
            .ToList();
    }

    /// <inheritdoc />
    public IList<Tuple<int, string, DateTime, string, string, string>> GetTerminationArchive()
    {
        return _employees
            .SelectMany(e => e.EmploymentHistory
                .Where(h => h.TerminationDate != null)
                .Select(h => Tuple.Create(
                    e.Id,
                    e.ToString(),
                    e.DateOfBirth,
                    e.Workshop,
                    e.Department,
                    h.Position
                )))
            .ToList();
    }

    /// <inheritdoc />
    public IDictionary<string, double> GetAverageAgeByDepartment()
    {
        DateTime today = DateTime.Today;
        return _employees
            .GroupBy(e => e.Department)
            .ToDictionary(
                g => g.Key,
                g => g.Average(e => (today - e.DateOfBirth).TotalDays / 365.25)
            );
    }

    /// <inheritdoc />
    public IList<Tuple<int, string, string>> GetEmployeesWithUnionBenefitsLastYear()
    {
        var lastYear = DateTime.Now.Year - 1;
        var result = _employees
            .Where(e => e.UnionMembership?.UnionBenefits
                .Any(b => b.BenefitDate.Year == lastYear) == true)
            .Select(e => Tuple.Create(
                e.Id,
                e.ToString(),
                string.Join(", ", e.UnionMembership.UnionBenefits
                    .Where(b => b.BenefitDate.Year == lastYear)
                    .Select(b => b.BenefitType))
            ))
            .ToList();

        return result;
    }

    /// <inheritdoc />
    public IList<Employee> GetTop5EmployeesBySeniority()
    {
        DateTime today = DateTime.Today;
        return _employees
            .OrderByDescending(e => (today - e.HireDate).TotalDays)
            .Take(5)
            .ToList();
    }
}