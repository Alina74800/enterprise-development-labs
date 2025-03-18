using AutoMapper;
using EnterpriseHR.Application.Contracts;
using EnterpriseHR.Application.Contracts.Department;
using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;

namespace EnterpriseHR.Application.Services;

/// <summary>
///     Служба слоя приложения для манипуляции над отделами.
/// </summary>
/// <param name="repository">Доменная служба для отделов.</param>
/// <param name="mapper">Автомаппер.</param>
public class DepartmentCrudService(IRepository<Department, int> repository, IMapper mapper)
    : ICrudService<DepartmentDto, DepartmentCreateUpdateDto, int>
{
    /// <summary>
    ///     Создает новый отдел.
    /// </summary>
    /// <param name="newDto">Данные для создания отдела.</param>
    /// <returns>True, если отдел успешно создан, иначе False.</returns>
    public bool Create(DepartmentCreateUpdateDto newDto)
    {
        Department? newDepartment = mapper.Map<Department>(newDto);
        newDepartment.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newDepartment);
        return result;
    }

    /// <summary>
    ///     Удаляет отдел по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <returns>True, если отдел успешно удален, иначе False.</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    ///     Получает отдел по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    /// <returns>Данные отдела или null, если отдел не найден.</returns>
    public DepartmentDto? GetById(int id)
    {
        Department? department = repository.Get(id);
        return mapper.Map<DepartmentDto>(department);
    }

    /// <summary>
    ///     Получает список всех отделов.
    /// </summary>
    /// <returns>Список всех отделов.</returns>
    public IList<DepartmentDto> GetList()
    {
        return mapper.Map<List<DepartmentDto>>(repository.GetAll());
    }

    /// <summary>
    ///     Обновляет данные отдела.
    /// </summary>
    /// <param name="key">Идентификатор отдела.</param>
    /// <param name="newDto">Новые данные отдела.</param>
    /// <returns>True, если данные успешно обновлены, иначе False.</returns>
    public bool Update(int key, DepartmentCreateUpdateDto newDto)
    {
        Department? oldDepartment = repository.Get(key);
        Department? newDepartment = mapper.Map<Department>(newDto);
        newDepartment.Id = key;
        newDepartment.Employees = oldDepartment?.Employees;
        var result = repository.Update(newDepartment);
        return result;
    }
}