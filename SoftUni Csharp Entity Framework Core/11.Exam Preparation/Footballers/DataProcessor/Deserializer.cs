namespace Footballers.DataProcessor;

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

    private const string SuccessfullyImportedCoach
        = "Successfully imported coach - {0} with {1} footballers.";

    private const string SuccessfullyImportedTeam
        = "Successfully imported team - {0} with {1} footballers.";

    public static string ImportCoaches(FootballersContext context, string xmlString)
    {
        var sb = new StringBuilder();
        var mapper = InitializeMapper();
        var xmlHelper = new XmlHelper();

        var coachesDtos = xmlHelper.DeserializeCollection<ImportCoachWithFootballersDto>(xmlString, "Coaches").ToArray();
        var validCoaches = new HashSet<Coach>();

        foreach (var coachDto in coachesDtos)
        {
            if (!IsValid(coachDto) || string.IsNullOrWhiteSpace(coachDto.Nationality) || string.IsNullOrWhiteSpace(coachDto.Name))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var mappedCoach = mapper.Map<Coach>(coachDto);

            foreach (var footballerDto in coachDto.Footballers)
            {
                if (!IsValid(footballerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var mappedFootballer = mapper.Map<Footballer>(footballerDto);

                if (mappedFootballer.ContractStartDate > mappedFootballer.ContractEndDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                mappedCoach.Footballers.Add(mappedFootballer);
            }

            validCoaches.Add(mappedCoach);
            sb.AppendLine(string.Format(SuccessfullyImportedCoach, mappedCoach.Name, mappedCoach.Footballers.Count));
        }

        context.Coaches.AddRange(validCoaches);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportTeams(FootballersContext context, string jsonString)
    {
        var sb = new StringBuilder();
        var mapper = InitializeMapper();

        var teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString)!;

        var footballerIdsInDb = context.Footballers.Select(f => f.Id).ToArray();
        var validTeams = new HashSet<Team>();

        foreach (var teamDto in teamDtos)
        {
            if (!IsValid(teamDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var mappedTeam = mapper.Map<Team>(teamDto);

            foreach (var footballerId in teamDto.Footballers)
            {
                if (footballerIdsInDb.All(fId => fId != footballerId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                mappedTeam.TeamsFootballers.Add(new TeamFootballer
                {
                    TeamId = mappedTeam.Id,
                    FootballerId = footballerId
                });
            }

            validTeams.Add(mappedTeam);
            sb.AppendLine(string.Format(SuccessfullyImportedTeam, mappedTeam.Name, mappedTeam.TeamsFootballers.Count));
        }

        context.Teams.AddRange(validTeams);
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
        cfg.AddProfile<FootballersProfile>();
    }));
}