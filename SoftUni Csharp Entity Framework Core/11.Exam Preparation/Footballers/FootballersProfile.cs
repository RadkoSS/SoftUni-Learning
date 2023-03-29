namespace Footballers;

using System.Globalization;
using AutoMapper;
using Data.Models;
using Data.Models.Enums;
using DataProcessor.ExportDto;
using DataProcessor.ImportDto;

// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
public class FootballersProfile : Profile
{
    public FootballersProfile()
    {
        this.CreateMap<ImportCoachWithFootballersDto, Coach>()
            .ForMember(d => d.Footballers, opt => opt.Ignore());

        this.CreateMap<Coach, ExportCoachWithFootballersDto>()
            .ForMember(d => d.FootballersCount, opt => opt.MapFrom(s => s.Footballers.Count))
            .ForMember(d => d.Footballers, opt => opt.MapFrom(s => s.Footballers.OrderBy(f => f.Name)));

        this.CreateMap<ImportFootballerDto, Footballer>()
            .ForMember(d => d.ContractStartDate, opt => opt.MapFrom(s => DateTime.ParseExact(s.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
            .ForMember(d => d.ContractEndDate, opt => opt.MapFrom(s => DateTime.ParseExact(s.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
            .ForMember(d => d.BestSkillType, opt => opt.MapFrom(s => (BestSkillType) s.BestSkillType))
            .ForMember(d => d.PositionType, opt => opt.MapFrom(s => (PositionType) s.PositionType));

        this.CreateMap<Footballer, ExportFootballerDto>()
            .ForMember(d => d.Position, opt => opt.MapFrom(s => s.PositionType.ToString()));

        this.CreateMap<ImportTeamDto, Team>()
            .ForMember(d => d.TeamsFootballers, opt => opt.Ignore());
    }
}