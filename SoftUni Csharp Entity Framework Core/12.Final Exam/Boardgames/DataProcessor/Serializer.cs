namespace Boardgames.DataProcessor;

using AutoMapper;
using Newtonsoft.Json;
using AutoMapper.QueryableExtensions;

using Data;
using ExportDto;
using Utilities;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        var xmlHelper = new XmlHelper();
        var mapper = InitializeMapper();

        var creatorsToExport = context.Creators
            .Where(c => c.Boardgames.Count >= 1)
            .OrderByDescending(c => c.Boardgames.Count)
            .ThenBy(c => c.FirstName)
            .ThenBy(c => c.LastName)
            .ProjectTo<ExportCreatorWithBoardgamesDto>(mapper.ConfigurationProvider)
            .ToArray();

        return xmlHelper.Serialize(creatorsToExport, "Creators");
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellersToExport = context.Sellers
            .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year) 
                        && s.BoardgamesSellers.Any(bs => bs.Boardgame.Rating <= rating))
            .Select(s => new
            {
                s.Name,
                s.Website,
                Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year 
                                 && bs.Boardgame.Rating <= rating)
                    .Select(bs => new
                {
                    bs.Boardgame.Name,
                    bs.Boardgame.Rating,
                    bs.Boardgame.Mechanics,
                    Category = bs.Boardgame.CategoryType.ToString()
                })
                    .OrderByDescending(bs => bs.Rating)
                    .ThenBy(bs => bs.Name)
                    .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Length)
            .ThenBy(s => s.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(sellersToExport, Formatting.Indented);
    }

    private static IMapper InitializeMapper() => new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<BoardgamesProfile>();
    }));
}