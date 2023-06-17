namespace Homies.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Seeding.TypeSeeder;

using Type = Models.Entities.Type;

internal class TypeEntityConfiguration : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.HasData(SeedTypes());
    }
}