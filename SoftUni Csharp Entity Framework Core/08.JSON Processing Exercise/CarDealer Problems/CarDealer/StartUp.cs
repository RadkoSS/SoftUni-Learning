namespace CarDealer;

using AutoMapper;
using Newtonsoft.Json;

using Data;
using Models;
using DTOs.Import;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new CarDealerContext();

        var jsonString = File.ReadAllText("../../../Datasets/cars.json");

        var result = ImportCars(dbContext, jsonString);

        Console.WriteLine(result);
    }

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        ImportSuppliersDto[] newSuppliers = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson)!;

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

    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        ImportPartsDto[] newParts = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson)!;

        ICollection<Part> validParts = new List<Part>();

        foreach (var newPart in newParts)
        {
            var searchedSupplier = context.Suppliers.FirstOrDefault(s => s.Id == newPart.SupplierId);

            if (searchedSupplier != null)
            {
                var mapped = mapper.Map<Part>(newPart);

                validParts.Add(mapped);
            }
        }

        context.Parts.AddRange(validParts);

        context.SaveChanges();

        return $"Successfully imported {validParts.Count}.";
    }

    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var mappper = CreateMapper();

        ImportCarsDto[] newCars = JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson)!;

        ICollection<Car> validCars = new List<Car>();

        foreach (var newCar in newCars)
        {
            var mapped = mappper.Map<Car>(newCar);

            validCars.Add(mapped);
        }

        context.Cars.AddRange(validCars);

        context.SaveChanges();

        return $"Successfully imported {validCars.Count}.";
    }

    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}