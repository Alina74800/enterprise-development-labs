using EnterpriseHR.Domain.Model;

namespace EnterpriseHR.Domain.Data;

/// <summary>
///     Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    ///     Список сотрудников
    /// </summary>
    public static readonly List<Employee> Employees =
    [
        new()
        {
            Id = 1,
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            DateOfBirth = new DateTime(1985, 5, 15),
            Gender = "Мужской",
            HireDate = new DateTime(2010, 6, 1),
            Workshop = "Цех №1",
            Department = "Отдел разработки",
            Position = "Инженер",
            HomeAddress = "ул. Ленина, д. 10",
            WorkPhone = "123-45-67",
            HomePhone = "987-65-43",
            MaritalStatus = "Женат",
            FamilyMembersCount = 3,
            ChildrenCount = 1
        },
        new()
        {
            Id = 2,
            LastName = "Петрова",
            FirstName = "Мария",
            Patronymic = "Сергеевна",
            DateOfBirth = new DateTime(1990, 8, 22),
            Gender = "Женский",
            HireDate = new DateTime(2015, 9, 10),
            Workshop = "Цех №2",
            Department = "Отдел тестирования",
            Position = "Тестировщик",
            HomeAddress = "ул. Пушкина, д. 5",
            WorkPhone = "234-56-78",
            HomePhone = "876-54-32",
            MaritalStatus = "Замужем",
            FamilyMembersCount = 4,
            ChildrenCount = 2
        },
        new()
        {
            Id = 3,
            LastName = "Сидоров",
            FirstName = "Алексей",
            Patronymic = "Алексеевич",
            DateOfBirth = new DateTime(1978, 3, 30),
            Gender = "Мужской",
            HireDate = new DateTime(2005, 7, 20),
            Workshop = "Цех №1",
            Department = "Отдел разработки",
            Position = "Старший инженер",
            HomeAddress = "ул. Гагарина, д. 7",
            WorkPhone = "345-67-89",
            HomePhone = "765-43-21",
            MaritalStatus = "Холост",
            FamilyMembersCount = 1,
            ChildrenCount = 0
        }
    ];

    /// <summary>
    ///     Список отделов
    /// </summary>
    public static readonly List<Department> Departments =
    [
        new()
        {
            Id = 1,
            Name = "Отдел разработки"
        },
        new()
        {
            Id = 2,
            Name = "Отдел тестирования"
        }
    ];

    /// <summary>
    ///     Список связей сотрудников и отделов
    /// </summary>
    public static readonly List<EmployeeDepartment> EmployeeDepartments =
    [
        new()
        {
            Id = 1,
            EmployeeId = 1,
            DepartmentId = 1
        },
        new()
        {
            Id = 2,
            EmployeeId = 2,
            DepartmentId = 2
        },
        new()
        {
            Id = 3,
            EmployeeId = 3,
            DepartmentId = 1
        },
        new()
        {
            Id = 4,
            EmployeeId = 1,
            DepartmentId = 2
        }
    ];

    /// <summary>
    ///     Список истории трудоустройства сотрудников
    /// </summary>
    public static readonly List<EmploymentHistory> EmploymentHistories =
    [
        new()
        {
            Id = 1,
            EmployeeId = 1,
            HireDate = new DateTime(2010, 6, 1),
            TerminationDate = null,
            Position = "Инженер"
        },
        new()
        {
            Id = 2,
            EmployeeId = 2,
            HireDate = new DateTime(2015, 9, 10),
            TerminationDate = null,
            Position = "Тестировщик"
        },
        new()
        {
            Id = 3,
            EmployeeId = 3,
            HireDate = new DateTime(2005, 7, 20),
            TerminationDate = new DateTime(2020, 12, 31),
            Position = "Старший инженер"
        }
    ];

    /// <summary>
    ///     Список членства в профсоюзе
    /// </summary>
    public static readonly List<UnionMembership> UnionMemberships =
    [
        new()
        {
            Id = 1,
            EmployeeId = 1,
            IsMember = true,
            UnionBenefits = new List<UnionBenefit>
            {
                new()
                {
                    Id = 1,
                    UnionMembershipId = 1,
                    BenefitDate = new DateTime(DateTime.Now.Year - 1, 5, 10),
                    BenefitType = "Санаторий"
                },
                new()
                {
                    Id = 2,
                    UnionMembershipId = 1,
                    BenefitDate = new DateTime(DateTime.Now.Year - 1, 8, 15),
                    BenefitType = "Дом отдыха"
                }
            }
        },
        new()
        {
            Id = 2,
            EmployeeId = 2,
            IsMember = false
        },
        new()
        {
            Id = 3,
            EmployeeId = 3,
            IsMember = true,
            UnionBenefits = new List<UnionBenefit>
            {
                new()
                {
                    Id = 3,
                    UnionMembershipId = 3,
                    BenefitDate = new DateTime(DateTime.Now.Year - 1, 10, 5),
                    BenefitType = "Санаторий"
                }
            }
        }
    ];

    /// <summary>
    ///     Список льгот от профсоюза
    /// </summary>
    public static readonly List<UnionBenefit> UnionBenefits =
    [
        new()
        {
            Id = 1,
            UnionMembershipId = 1,
            BenefitDate = new DateTime(DateTime.Now.Year - 1, 5, 10),
            BenefitType = "Санаторий"
        },
        new()
        {
            Id = 2,
            UnionMembershipId = 1,
            BenefitDate = new DateTime(DateTime.Now.Year - 1, 8, 15),
            BenefitType = "Дом отдыха"
        },
        new()
        {
            Id = 3,
            UnionMembershipId = 2,
            BenefitDate = new DateTime(DateTime.Now.Year - 2, 3, 20),
            BenefitType = "Пионерский лагерь"
        },
        new()
        {
            Id = 4,
            UnionMembershipId = 3,
            BenefitDate = new DateTime(DateTime.Now.Year - 1, 10, 5),
            BenefitType = "Санаторий"
        },
        new()
        {
            Id = 5,
            UnionMembershipId = 3,
            BenefitDate = new DateTime(DateTime.Now.Year, 1, 15),
            BenefitType = "Дом отдыха"
        }
    ];

    /// <summary>
    ///     Статический конструктор для инициализации связей между объектами
    /// </summary>
    static DataSeeder()
    {
        foreach (EmployeeDepartment ed in EmployeeDepartments)
        {
            ed.Employee = Employees.FirstOrDefault(e => e.Id == ed.EmployeeId);
            ed.Department = Departments.FirstOrDefault(d => d.Id == ed.DepartmentId);
        }

        foreach (EmploymentHistory eh in EmploymentHistories)
        {
            eh.Employee = Employees.FirstOrDefault(e => e.Id == eh.EmployeeId);
        }

        foreach (UnionMembership um in UnionMemberships)
        {
            um.Employee = Employees.FirstOrDefault(e => e.Id == um.EmployeeId);
        }

        foreach (UnionBenefit ub in UnionBenefits)
        {
            ub.UnionMembership = UnionMemberships.FirstOrDefault(um => um.Id == ub.UnionMembershipId);
        }

        foreach (Employee e in Employees)
        {
            e.EmployeeDepartments = EmployeeDepartments.Where(ed => ed.EmployeeId == e.Id).ToList();
            e.EmploymentHistory = EmploymentHistories.Where(eh => eh.EmployeeId == e.Id).ToList();
            e.UnionMembership = UnionMemberships.FirstOrDefault(um => um.EmployeeId == e.Id);
        }
    }
}