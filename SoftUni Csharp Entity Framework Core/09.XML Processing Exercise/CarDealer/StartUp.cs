namespace CarDealer2;

using AutoMapper;

using Data;
using Models;
using Utilities;
using DTOs.Import;

public class StartUp
{
    public static void Main()
    {
        using CarDealer2Context dbContext = new CarDealer2Context();

        var xmlInput = File.ReadAllText("../../../Datasets/suppliers.xml");

        var result = ImportSuppliers(dbContext, xmlInput);

        Console.WriteLine(result);
    }

    public static string ImportSuppliers(CarDealer2Context context, string inputXml)
    {
        XmlHelper xmlHelper = new XmlHelper();

        IMapper mapper = InitializeAutoMapper();

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

    private static IMapper InitializeAutoMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}