namespace CarDealer;

using AutoMapper;
using Newtonsoft.Json;

using Data;
using DTOs.Import;
using Models;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new CarDealerContext();

        var jsonString = File.ReadAllText("../../../Datasets/suppliers.json");

        var result = ImportSuppliers(dbContext, jsonString);

        Console.WriteLine(result);
    }

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        SupplierDto[] newSuppliers = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson)!;

        ICollection<Supplier> validSuppliers = new List<Supplier>();

        foreach (var newSupplier in newSuppliers)
        {
            var mapped = mapper.Map<Supplier>(newSupplier);

            validSuppliers.Add(mapped);
        }

        context.Suppliers.AddRange(validSuppliers);

        context.SaveChanges();

        return $"Successfully imported {validSuppliers.Count}.";
    }

    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}