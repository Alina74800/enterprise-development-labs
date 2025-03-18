using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services.InMemory;

namespace EnterpriseHR.Domain.Tests;

/// <summary>
///     Тестовый класс для проверки функциональности сервиса сотрудников.
/// </summary>
public class EmployeeServiceTests
{
    /// <summary>
    ///     Тест для проверки запроса 1: Получение сотрудников выбранного отдела.
    /// </summary>
    [Fact]
    public void GetEmployeesByDepartment_ShouldReturnCorrectEmployees()
    {
        var department = "Отдел разработки";
        var repo = new EmployeeInMemoryRepository();
        IList<Employee> result = repo.GetEmployeesByDepartment(department);

        Assert.Equal(2, result.Count);
        Assert.All(result, e => Assert.Equal(department, e.Department));
    }

    /// <summary>
    ///     Тест для проверки запроса 2: Получение сотрудников, работающих в нескольких отделах, с сортировкой по ФИО.
    /// </summary>
    [Fact]
    public void GetEmployeesInMultipleDepartments_ShouldReturnCorrectEmployees()
    {
        var repo = new EmployeeInMemoryRepository();
        IList<Employee> result = repo.GetEmployeesInMultipleDepartments();

        Assert.Single(result);
        Assert.Equal("Иванов Иван Иванович", result[0].ToString());
    }

    /// <summary>
    ///     Тест для проверки запроса 3: Получение архива уволенных сотрудников.
    /// </summary>
    [Fact]
    public void GetTerminationArchive_ShouldReturnCorrectData()
    {
        var repo = new EmployeeInMemoryRepository();
        IList<Tuple<int, string, DateTime, string, string, string>> result = repo.GetTerminationArchive();

        Assert.Single(result);
        Tuple<int, string, DateTime, string, string, string> terminationRecord = result[0];

        Assert.Equal(3, terminationRecord.Item1);
        Assert.Equal("Сидоров Алексей Алексеевич", terminationRecord.Item2);
        Assert.Equal(new DateTime(1978, 3, 30), terminationRecord.Item3);
        Assert.Equal("Цех №1", terminationRecord.Item4);
        Assert.Equal("Отдел разработки", terminationRecord.Item5);
        Assert.Equal("Старший инженер", terminationRecord.Item6);
    }

    /// <summary>
    ///     Тест для проверки запроса 4: Получение среднего возраста сотрудников по отделам.
    /// </summary>
    [Fact]
    public void GetAverageAgeByDepartment_ShouldReturnCorrectAges()
    {
        var repo = new EmployeeInMemoryRepository();
        IDictionary<string, double> result = repo.GetAverageAgeByDepartment();

        Assert.Equal(2, result.Count);
        Assert.True(result["Отдел разработки"] > 0);
        Assert.True(result["Отдел тестирования"] > 0);
    }

    /// <summary>
    ///     Тест для проверки запроса 5: Получение сотрудников, получавших льготные путевки в прошлом году.
    /// </summary>
    [Fact]
    public void GetEmployeesWithUnionBenefitsLastYear_ShouldReturnCorrectData()
    {
        var repo = new EmployeeInMemoryRepository();
        IList<Tuple<int, string, string>> result = repo.GetEmployeesWithUnionBenefitsLastYear();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        Tuple<int, string, string>? employee1Record = result.FirstOrDefault(r => r.Item1 == 1);
        Assert.NotNull(employee1Record);
        Assert.Equal("Иванов Иван Иванович", employee1Record.Item2);
        Assert.Equal("Санаторий, Дом отдыха", employee1Record.Item3);

        Tuple<int, string, string>? employee3Record = result.FirstOrDefault(r => r.Item1 == 3);
        Assert.NotNull(employee3Record);
        Assert.Equal("Сидоров Алексей Алексеевич", employee3Record.Item2);
        Assert.Equal("Санаторий", employee3Record.Item3);
    }

    /// <summary>
    ///     Тест для проверки запроса 6: Получение топ-5 сотрудников с наибольшим стажем.
    /// </summary>
    [Fact]
    public void GetTop5EmployeesBySeniority_ShouldReturnCorrectEmployees()
    {
        var repo = new EmployeeInMemoryRepository();
        IList<Employee> result = repo.GetTop5EmployeesBySeniority();

        Assert.Equal(3, result.Count);
        Assert.Equal("Сидоров Алексей Алексеевич", result[0].ToString());
    }
}