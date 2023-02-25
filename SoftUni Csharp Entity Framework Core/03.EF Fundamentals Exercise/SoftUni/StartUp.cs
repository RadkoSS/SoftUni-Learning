using SoftUni.Data;

namespace SoftUni;

using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

public class StartUp
{
    static async Task Main()
    {
        SoftUniContext context = new SoftUniContext();

        string result = AddNewAddressToEmployee(context);

        Console.WriteLine(result);
    }

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

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        return string.Join(Environment.NewLine, context.Employees.Where(e => e.Salary > 50000).OrderBy(e => e.FirstName).Select(e => $"{e.FirstName} - {e.Salary:f2}").ToArray());
    }

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
}