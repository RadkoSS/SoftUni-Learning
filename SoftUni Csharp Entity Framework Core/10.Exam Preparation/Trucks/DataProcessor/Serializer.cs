namespace Trucks.DataProcessor;

using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using Data;
using ExportDto;
using Utilities;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        var xmlHelper = new XmlHelper();
        var mapper = CreateMapper();

        var despatchers = context.Despatchers
            .Where(d => d.Trucks.Count >= 1)
            .ProjectTo<ExportDespatchersAndTrucksDto>(mapper.ConfigurationProvider)
            .OrderByDescending(d => d.Trucks.Length)
            .ThenBy(d => d.Name)
            .ToArray();

        return xmlHelper.Serialize(despatchers, "Despatchers");
    }

    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var clients = context.Clients
            .Include(c => c.ClientsTrucks)
            .ThenInclude(c => c.Truck)
            .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
            .AsNoTracking()
            .ToArray()
            .Select(c => new
            {
                c.Name,
                Trucks = c.ClientsTrucks
                    .Where(t => t.Truck.TankCapacity >= capacity)
                    .Select(t => new
                {
                    TruckRegistrationNumber = t.Truck.RegistrationNumber,
                    t.Truck.VinNumber,
                    t.Truck.TankCapacity,
                    t.Truck.CargoCapacity,
                    CategoryType = Enum.GetName(t.Truck.CategoryType),
                    MakeType = Enum.GetName(t.Truck.MakeType)
                })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
                    .ToArray()
            })
            .OrderByDescending(c => c.Trucks.Length)
            .ThenBy(c => c.Name)
            .Take(10)
            .ToArray();

        return JsonConvert.SerializeObject(clients, Formatting.Indented);
    }

    private static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<TrucksProfile>();
    }));
}