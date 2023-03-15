namespace CarDealer;

using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using Data;
using Models;
using DTOs.Import;
using DTOs.Export;

public class StartUp
{
    public static void Main()
    {
        using var dbContext = new CarDealerContext();

        //var jsonString = File.ReadAllText("../../../Datasets/sales.json");

        var result = GetOrderedCustomers(dbContext);

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

    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        ImportCustomerDto[] newCustomers = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson)!;

        Customer[] validCustomers = mapper.Map<Customer[]>(newCustomers);

        context.Customers.AddRange(validCustomers);

        context.SaveChanges();

        return $"Successfully imported {validCustomers.Length}.";
    }

    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var mapper = CreateMapper();

        ImportSaleDto[] newSales = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson)!;

        ICollection<Sale> validSales = new HashSet<Sale>();

        foreach (var sale in newSales)
        {
            if (!context.Customers.Any(c => c.Id == sale.CustomerId) || !context.Cars.Any(c => c.Id == sale.CarId))
            {
                continue;
            }

            var mappedSale = mapper.Map<Sale>(sale);

            validSales.Add(mappedSale);
        }

        context.Sales.AddRange(validSales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}.";
    }

    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var mapper = CreateMapper();

        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .AsNoTracking()
            .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider).ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}