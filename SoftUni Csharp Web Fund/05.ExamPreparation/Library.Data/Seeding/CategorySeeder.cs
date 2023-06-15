namespace Library.Data.Seeding;

using Models.Entities;

internal static class CategorySeeder
{
    internal static Category[] SeedCategories()
    {
        return new Category[]
        {
            new Category()
            {
                Id = 1,
                Name = "Action"
            },
            new Category()
            {
                Id = 2,
                Name = "Biography"
            },
            new Category()
            {
                Id = 3,
                Name = "Children"
            },
            new Category()
            {
                Id = 4,
                Name = "Crime"
            },
            new Category()
            {
                Id = 5,
                Name = "Fantasy"
            }
        };
    }
}