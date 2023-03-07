namespace BookShop;

using System.Linq;

using Data;
using Initializer;
using Models.Enums;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        string result = GetBooksByAgeRestriction(dbContext, Console.ReadLine()!);

        Console.WriteLine(result);
    }
        
    public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
    {
        try
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var result = dbContext.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
    }
}