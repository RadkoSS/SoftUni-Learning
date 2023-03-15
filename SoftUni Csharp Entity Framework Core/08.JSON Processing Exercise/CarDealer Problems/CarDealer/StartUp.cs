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

        ImportSupplierDto[] newSuppliers = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson)!;

        ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

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

        ImportPartDto[] newParts = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson)!;

        ICollection<Part> validParts = new HashSet<Part>();

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

    //TODO
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        ImportCarDto[] newCars = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson)!;

        ICollection<PartCar> partsCars = new HashSet<PartCar>();
        int importedCars = 0;

        foreach (var newCar in newCars)
        {
            var mappedCar = mapper.Map<Car>(newCar);
            context.Cars.Add(mappedCar);
            context.SaveChanges();
            importedCars++;

            foreach (var partId in newCar.PartsCollection)
            {
                if (!context.Parts.Any(p => p.Id == partId))
                {
                    continue;
                }

                var partCar = new PartCar
                {
                    CarId = mappedCar.Id,
                    PartId = partId
                };

                partsCars.Add(partCar);
            }
        }

        context.PartsCars.AddRange(partsCars);
        context.SaveChanges();

        return $"Successfully imported {importedCars}.";
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}