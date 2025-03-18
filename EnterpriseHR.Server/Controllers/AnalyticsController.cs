using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseHR.Server.Controllers;

/// <summary>
///     Контроллер для выполнения аналитических запросов.
/// </summary>
/// <param name="service">Служба для выполнения аналитических запросов.</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service) : ControllerBase
{
    /// <summary>
    ///     Получение списка сотрудников по указанному отделу.
    /// </summary>
    /// <param name="department">Название отдела.</param>
    /// <returns>Список сотрудников в указанном отделе.</returns>
    [HttpGet("EmployeesByDepartment/{department}")]
    [ProducesResponseType(200)]
    public ActionResult<List<Employee>> GetEmployeesByDepartment(string department)
    {
        return Ok(service.GetEmployeesByDepartment(department));
    }

    /// <summary>
    ///     Получение списка сотрудников, работающих в нескольких отделах, с сортировкой по ФИО.
    /// </summary>
    /// <returns>Список сотрудников, работающих в нескольких отделах.</returns>
    [HttpGet("EmployeesInMultipleDepartments")]
    [ProducesResponseType(200)]
    public ActionResult<List<Employee>> GetEmployeesInMultipleDepartments()
    {
        return Ok(service.GetEmployeesInMultipleDepartments());
    }

    /// <summary>
    ///     Получение архива уволенных сотрудников.
    /// </summary>
    /// <returns>Список данных об уволенных сотрудниках.</returns>
    [HttpGet("TerminationArchive")]
    [ProducesResponseType(200)]
    public ActionResult<List<Tuple<int, string, DateTime, string, string, string>>> GetTerminationArchive()
    {
        return Ok(service.GetTerminationArchive());
    }

    /// <summary>
    ///     Получение среднего возраста сотрудников по отделам.
    /// </summary>
    /// <returns>Словарь, где ключ — название отдела, а значение — средний возраст.</returns>
    [HttpGet("AverageAgeByDepartment")]
    [ProducesResponseType(200)]
    public ActionResult<IDictionary<string, double>> GetAverageAgeByDepartment()
    {
        return Ok(service.GetAverageAgeByDepartment());
    }

    /// <summary>
    ///     Получение сведений о сотрудниках, получавших льготные путевки в прошлом году.
    /// </summary>
    /// <returns>Список данных о сотрудниках и видах полученных путевок.</returns>
    [HttpGet("EmployeesWithUnionBenefitsLastYear")]
    [ProducesResponseType(200)]
    public ActionResult<List<Tuple<int, string, string>>> GetEmployeesWithUnionBenefitsLastYear()
    {
        return Ok(service.GetEmployeesWithUnionBenefitsLastYear());
    }

    /// <summary>
    ///     Получение топ-5 сотрудников с наибольшим стажем работы на предприятии.
    /// </summary>
    /// <returns>Список сотрудников с наибольшим стажем.</returns>
    [HttpGet("Top5EmployeesBySeniority")]
    [ProducesResponseType(200)]
    public ActionResult<List<Employee>> GetTop5EmployeesBySeniority()
    {
        return Ok(service.GetTop5EmployeesBySeniority());
    }
}