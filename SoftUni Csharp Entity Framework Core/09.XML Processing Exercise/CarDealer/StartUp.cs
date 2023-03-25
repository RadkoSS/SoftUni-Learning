namespace CarDealer;

using System.IO;
using AutoMapper;

using Data;
using Models;
using Utilities;
using DTOs.Import;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext dbContext = new CarDealerContext();

        var xmlInput = File.ReadAllText("../../../Datasets/sales.xml");

        var result = ImportSales(dbContext, xmlInput);

        Console.WriteLine(result);
    }

    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportSupplierDto[] supplierDtos = xmlHelper.DeserializeCollection<ImportSupplierDto>(inputXml, "Suppliers").ToArray();

        var validSuppliers = new HashSet<Supplier>();

        foreach (var supplierDto in supplierDtos)
        {
            var mappedSupplier = mapper.Map<Supplier>(supplierDto);

            validSuppliers.Add(mappedSupplier);
        }

        context.Suppliers.AddRange(validSuppliers);

        context.SaveChanges();

        return $"Successfully imported {validSuppliers.Count}";
    }

    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportPartDto[] partsDtos = xmlHelper.DeserializeCollection<ImportPartDto>(inputXml, "Parts").ToArray();

        var supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

        var validParts = new HashSet<Part>();

        foreach (var partDto in partsDtos)
        {
            if (supplierIds.Contains(partDto.SupplierId))
            {
                var mappedPart = mapper.Map<Part>(partDto);

                validParts.Add(mappedPart);
            }
        }

        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}";
    }

    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportCarDto[] carDtos = xmlHelper.DeserializeCollection<ImportCarDto>(inputXml, "Cars").ToArray();

        var partIds = context.Parts.Select(p => p.Id).ToArray();

        var validCars = new HashSet<Car>();

        foreach (var carDto in carDtos)
        {
            if (string.IsNullOrWhiteSpace(carDto.Make) || string.IsNullOrWhiteSpace(carDto.Model))
            {
                continue;
            }

            var mappedCar = mapper.Map<Car>(carDto);

            foreach (var part in carDto.Parts.DistinctBy(p => p.PartId))
            {
                if (partIds.All(pi => pi != part.PartId))
                {
                    continue;
                }

                PartCar partCar = new PartCar
                {
                    PartId = part.PartId
                };

                mappedCar.PartsCars.Add(partCar);
            }

            validCars.Add(mappedCar);
        }

        context.Cars.AddRange(validCars);

        context.SaveChanges();

        return $"Successfully imported {validCars.Count}";
    }

    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportCustomerDto[] customerDtos = xmlHelper.DeserializeCollection<ImportCustomerDto>(inputXml, "Customers").ToArray();

        var validCustomers = new HashSet<Customer>();

        foreach (var customerDto in customerDtos)
        {
            if (string.IsNullOrWhiteSpace(customerDto.Name) || string.IsNullOrWhiteSpace(customerDto.BirthDate))
            {
                continue;
            }

            var mappedCustomer = mapper.Map<Customer>(customerDto);

            validCustomers.Add(mappedCustomer);
        }

        context.Customers.AddRange(validCustomers);

        context.SaveChanges();

        return $"Successfully imported {validCustomers.Count}";
    }

    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        IMapper mapper = InitializeAutoMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportSaleDto[] saleDtos = xmlHelper.DeserializeCollection<ImportSaleDto>(inputXml, "Sales").ToArray();

        var carIds = context.Cars.Select(c => c.Id).ToArray();

        var validSales = new HashSet<Sale>();

        foreach (var saleDto in saleDtos)
        {
            if (carIds.All(c => c != saleDto.CarId))
            {
                continue;
            }

            var mappedSale = mapper.Map<Sale>(saleDto);

            validSales.Add(mappedSale);
        }

        context.Sales.AddRange(validSales);

        context.SaveChanges();

        return $"Successfully imported {validSales.Count}";
    }

    private static IMapper InitializeAutoMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}