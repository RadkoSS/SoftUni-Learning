namespace P01_StudentSystem;

using Data;

public class StartUp
{
    static async Task Main()
    {
        StudentSystemContext context = new StudentSystemContext();

        await context.Database.EnsureDeletedAsync();

        await context.Database.EnsureCreatedAsync();
    }
}