namespace Homies.Data.Seeding;

using Type = Models.Entities.Type;

internal static class TypeSeeder
{
    internal static Type[] SeedTypes()
    {
        return new Type[]
        {
            new Type()
            {
                Id = 1,
                Name = "Animals"
            },
            new Type()
            {
                Id = 2,
                Name = "Fun"
            },
            new Type()
            {
                Id = 3,
                Name = "Discussion"
            },
            new Type()
            {
                Id = 4,
                Name = "Work"
            }
        };
    }
}