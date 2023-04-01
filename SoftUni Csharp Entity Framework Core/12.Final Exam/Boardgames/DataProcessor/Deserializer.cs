namespace Boardgames.DataProcessor;

using AutoMapper;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

using Data;
using Utilities;
using ImportDto;
using Data.Models;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        var mapper = InitializeMapper();
        var xmlHelper = new XmlHelper();
        var sb = new StringBuilder();

        var creatorDtos = xmlHelper.DeserializeCollection<ImportCreatorWithBoardgamesDto>(xmlString, "Creators").ToArray();

        var validCreators = new HashSet<Creator>();

        foreach (var creatorDto in creatorDtos)
        {
            if (!IsValid(creatorDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var mappedCreator = mapper.Map<Creator>(creatorDto);

            foreach (var boardgameDto in creatorDto.Boardgames)
            {
                if (!IsValid(boardgameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var mappedBoardgame = mapper.Map<Boardgame>(boardgameDto);

                mappedCreator.Boardgames.Add(mappedBoardgame);
            }

            validCreators.Add(mappedCreator);

            sb.AppendLine(string.Format(SuccessfullyImportedCreator, mappedCreator.FirstName, mappedCreator.LastName, mappedCreator.Boardgames.Count));
        }

        context.Creators.AddRange(validCreators);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        var mapper = InitializeMapper();
        var sb = new StringBuilder();

        var sellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString)!;

        var boardgamesIdsInDb = context.Boardgames.Select(bg => bg.Id).ToArray();

        var validSellers = new HashSet<Seller>();

        foreach (var sellerDto in sellerDtos)
        {
            if (!IsValid(sellerDto) || string.IsNullOrWhiteSpace(sellerDto.Country))
            {
                sb.AppendLine(ErrorMessage); 
                continue;
            }

            var mappedSeller = mapper.Map<Seller>(sellerDto);

            foreach (var boardgameId in sellerDto.Boardgames)
            {
                if (!boardgamesIdsInDb.Contains(boardgameId))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                mappedSeller.BoardgamesSellers.Add(new BoardgameSeller
                {
                    BoardgameId = boardgameId
                });
            }

            validSellers.Add(mappedSeller);

            sb.AppendLine(string.Format(SuccessfullyImportedSeller, mappedSeller.Name, mappedSeller.BoardgamesSellers.Count));
        }

        context.Sellers.AddRange(validSellers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }

    private static IMapper InitializeMapper() => new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<BoardgamesProfile>();
    }));
}