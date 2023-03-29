namespace Footballers.DataProcessor;

using AutoMapper;
using Newtonsoft.Json;
using System.Globalization;
using AutoMapper.QueryableExtensions;

using Data;
using ExportDto;
using Utilities;

public class Serializer
{
    public static string ExportCoachesWithTheirFootballers(FootballersContext context)
    {
        var xmlHelper = new XmlHelper();
        var mapper = InitializeMapper();

        var coaches = context.Coaches
            .Where(c => c.Footballers.Count >= 1)
            .OrderByDescending(c => c.Footballers.Count)
            .ThenBy(c => c.Name)
            .ProjectTo<ExportCoachWithFootballersDto>(mapper.ConfigurationProvider)
            .ToArray();

        return xmlHelper.Serialize(coaches, "Coaches");
    }

    public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
    {
        var teams = context.Teams
            .Where(t => t.TeamsFootballers.Count(tf => tf.Footballer.ContractStartDate >= date) >= 1)
            .ToArray()
            .Select(t => new
            {
                t.Name,
                Footballers = t.TeamsFootballers
                    .Where(tf => tf.Footballer.ContractStartDate >= date)
                    .OrderByDescending(f => f.Footballer.ContractEndDate)
                    .ThenBy(f => f.Footballer.Name)
                    .Select(tf => new
                {
                    FootballerName = tf.Footballer.Name,
                    ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                    ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                    BestSkillType = tf.Footballer.BestSkillType.ToString(),
                    PositionType = tf.Footballer.PositionType.ToString()
                })
                    .ToArray()
            })
            .OrderByDescending(t => t.Footballers.Length)
            .ThenBy(t => t.Name)
            .Take(5)
            .ToArray();

        return JsonConvert.SerializeObject(teams, Formatting.Indented);
    }

    private static IMapper InitializeMapper() => new Mapper(new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<FootballersProfile>();
    }));
}