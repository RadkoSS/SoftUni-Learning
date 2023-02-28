using SoftUni.Data;

namespace SoftUni;

using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

public class StartUp
{
    static async Task Main()
    {
        SoftUniContext context = new SoftUniContext();

        string result = IncreaseSalaries(context);

        Console.WriteLine(result);
    }

    //Problem 03
    public static async Task<string> GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = await context.Employees.OrderBy(e => e.EmployeeId).Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary }).ToListAsync();

        StringBuilder sb = new StringBuilder();

        employees.ForEach(e =>
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        });

        return sb.ToString().TrimEnd();
    }

    //Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        return string.Join(Environment.NewLine, context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName).Select(e => $"{e.FirstName} - {e.Salary:f2}").ToArray());
    }

    //Problem 05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary }).OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).ToList();

        var sb = new StringBuilder();

        employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}"));

        return sb.ToString().TrimEnd();
    }

    //Problem 06
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        var newAddress = new Address
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

        employee!.Address = newAddress;

        context.SaveChanges();

        return string.Join(Environment.NewLine,
            context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address!.AddressText));
    }

    //Problem 07
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Take(10).Select(e =>
                new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects
                        .Where(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            p.Project.Name,
                            StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                        }).ToArray()
                }).ToArray();

        var sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb.AppendLine($"{p.Name} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments.Select(d => new
        {
            d.Name,
            ManagerFirstName = d.Manager.FirstName,
            ManagerLastName = d.Manager.LastName,
            Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
        }).Where(d => d.Employees.Count > 5).OrderBy(d => d.Employees.Count).ThenBy(d => d.Name).ToArray();

        var sb = new StringBuilder();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var employees = context.Employees.Where(e =>
            e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
            e.Department.Name == "Information Services" || e.Department.Name == "Marketing")
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName).ToList();

        employees.ForEach(e =>
            {
                e.Salary *= 1.2m;
            }
        );

        context.SaveChanges();

        var sb = new StringBuilder();

        employees.ForEach(e =>
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
        });


        return sb.ToString().TrimEnd();
    }

    //Problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees.Select(e => new
        {
            e.FirstName,
            e.LastName,
            e.JobTitle,
            Salary = $"{e.Salary:f2}"
        }).Where(e => e.FirstName.StartsWith("Sa")).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

        var sb = new StringBuilder();

        employees.ForEach(e =>
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
        });
        return sb.ToString().TrimEnd();
    }

    //Problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {
        var projectsToDelete = context.EmployeesProjects.Where(p => p.ProjectId == 2).ToArray();

        context.EmployeesProjects.RemoveRange(projectsToDelete);

        var projectsToDelete2 = context.Projects.Where(p => p.ProjectId == 2).ToArray();

        context.Projects.RemoveRange(projectsToDelete2);

        context.SaveChanges();

        return string.Join(Environment.NewLine, context.Projects.Take(10).Select(p => p.Name));
    }

    //Problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        var townToDelete = context
            .Towns
            .FirstOrDefault(t => t.Name == "Seattle");

        var referredAddresses = context
            .Addresses
            .Where(a => a.TownId == townToDelete!.TownId)
            .ToList();

        foreach (var employee in context.Employees)
        {
            referredAddresses.ForEach(a =>
            {
                if (employee.AddressId == a.AddressId)
                {
                    employee.AddressId = null;
                }
            });
        }

        context.Addresses.RemoveRange(referredAddresses);
        context.Towns.Remove(townToDelete!);

        context.SaveChanges();

        return $"{referredAddresses.Count} addresses in Seattle were deleted";
    }
}