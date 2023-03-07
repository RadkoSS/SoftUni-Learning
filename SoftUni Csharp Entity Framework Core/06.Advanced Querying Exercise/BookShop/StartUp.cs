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

        string result = GetBooksByPrice(dbContext);

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
                .ToArray();

            return string.Join(Environment.NewLine, result);
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
    }

    public static string GetBooksByPrice(BookShopContext dbContext)
    {
        var result = dbContext.Books
            .Where(b => b.Price > 40)
            .Select(b => new
                        {
                            b.Title,
                            b.Price
                        })
            .OrderByDescending(b => b.Price)
            .ToArray()
            .Select(b => $"{b.Title} - ${b.Price:f2}");

        return string.Join(Environment.NewLine, result);
    }
}