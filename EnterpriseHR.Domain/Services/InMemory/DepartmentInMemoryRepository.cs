using EnterpriseHR.Domain.Model;
using EnterpriseHR.Domain.Services;

namespace EnterpriseHR.Domain.Services.InMemory;

/// <summary>
///     Реализация репозитория для работы с отделами в памяти.
///     Этот класс предоставляет CRUD-операции для объектов типа Department.
/// </summary>
public class DepartmentInMemoryRepository : IRepository<Department, int>
{
    /// <summary>
    ///     Внутренний список для хранения отделов в памяти.
    /// </summary>
    private readonly List<Department> _departments = new();

    /// <summary>
    ///     Добавляет новый отдел в репозиторий.
    /// </summary>
    /// <param name="entity">Объект отдела, который нужно добавить.</param>
    /// <returns>Всегда возвращает true, так как добавление всегда успешно.</returns>
    public bool Add(Department entity)
    {
        _departments.Add(entity);
        return true;
    }

    /// <summary>
    ///     Удаляет отдел из репозитория по его уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела, который нужно удалить.</param>
    /// <returns>
    ///     Возвращает true, если отдел был найден и удален.
    ///     Возвращает false, если отдел с указанным идентификатором не найден.
    /// </returns>
    public bool Delete(int id)
    {
        var department = _departments.FirstOrDefault(d => d.Id == id);
        if (department != null)
        {
            _departments.Remove(department);
            return true;
        }
        return false;
    }

    /// <summary>
    ///     Получает отдел по его уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела, который нужно получить.</param>
    /// <returns>
    ///     Возвращает объект отдела, если он найден.
    ///     Возвращает null, если отдел с указанным идентификатором не найден.
    /// </returns>
    public Department? Get(int id)
    {
        return _departments.FirstOrDefault(d => d.Id == id);
    }

    /// <summary>
    ///     Получает все отделы, хранящиеся в репозитории.
    /// </summary>
    /// <returns>Список всех отделов.</returns>
    public IList<Department> GetAll()
    {
        return _departments;
    }

    /// <summary>
    ///     Обновляет информацию об отделе в репозитории.
    /// </summary>
    /// <param name="entity">Обновленный объект отдела.</param>
    /// <returns>
    ///     Возвращает true, если отдел был найден и обновлен.
    ///     Возвращает false, если отдел с указанным идентификатором не найден.
    /// </returns>
    public bool Update(Department entity)
    {
        var existingDepartment = _departments.FirstOrDefault(d => d.Id == entity.Id);
        if (existingDepartment != null)
        {
            _departments.Remove(existingDepartment);
            _departments.Add(entity);
            return true;
        }
        return false;
    }
}