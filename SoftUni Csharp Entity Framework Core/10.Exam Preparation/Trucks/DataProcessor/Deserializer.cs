namespace Trucks.DataProcessor;

using AutoMapper;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

using Data;
using ImportDto;
using Utilities;
using Data.Models;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        var sb = new StringBuilder();
        var xmlHelper = new XmlHelper();
        var mapper = CreateMapper();

        ImportDespatcherDto[] despatcherDtos = xmlHelper.DeserializeCollection<ImportDespatcherDto>(xmlString, "Despatchers").ToArray();

        var validDespatchers = new HashSet<Despatcher>();
        foreach (var despatcherDto in despatcherDtos)
        {
            if (!IsValid(despatcherDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var mappedDespatcher = mapper.Map<Despatcher>(despatcherDto);

            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var mappedTruck = mapper.Map<Truck>(truckDto);

                mappedDespatcher.Trucks.Add(mappedTruck);
            }
            
            validDespatchers.Add(mappedDespatcher);

            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, mappedDespatcher.Name, mappedDespatcher.Trucks.Count));
        }

        context.Despatchers.AddRange(validDespatchers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }
    public static string ImportClient(TrucksContext context, string jsonString)
    {
        var sb = new StringBuilder();
        var mapper = CreateMapper();

        ImportClientDto[] clientsDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString)!;

        int[] allTruckIdsInDb = context.Trucks.Select(t => t.Id).ToArray();

        var validClients = new HashSet<Client>();

        foreach (var clientDto in clientsDtos)
        {
            if (!IsValid(clientDto) || clientDto.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var mappedClient = mapper.Map<Client>(clientDto);

            foreach (var truckId in clientDto.Trucks)
            {
                if (allTruckIdsInDb.All(tid => tid != truckId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                mappedClient.ClientsTrucks.Add(new ClientTruck
                {
                    TruckId = truckId
                });
            }

            validClients.Add(mappedClient);

            sb.AppendLine(
                string.Format(SuccessfullyImportedClient, mappedClient.Name, mappedClient.ClientsTrucks.Count));
        }

        context.Clients.AddRange(validClients);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<TrucksProfile>();
    }));
}