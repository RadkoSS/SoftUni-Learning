namespace Boardgames;

using AutoMapper;

using Data.Models;
using Data.Models.Enums;
using DataProcessor.ExportDto;
using DataProcessor.ImportDto;

public class BoardgamesProfile : Profile
{
    public BoardgamesProfile()
    {
        //Creator mappings
        this.CreateMap<ImportCreatorWithBoardgamesDto, Creator>()
            .ForMember(d => d.Boardgames, opt => opt.Ignore());

        this.CreateMap<Creator, ExportCreatorWithBoardgamesDto>()
            .ForMember(d => d.CreatorFullName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
            .ForMember(d => d.BoardgamesCount, opt => opt.MapFrom(s => s.Boardgames.Count))
            .ForMember(d => d.Boardgames, opt => opt.MapFrom(s => s.Boardgames.OrderBy(b => b.Name)));

        //Boardgame mappings
        this.CreateMap<ImportBoardgameDto, Boardgame>()
            .ForMember(d => d.CategoryType, opt => opt.MapFrom(s => (CategoryType) s.CategoryType));

        this.CreateMap<Boardgame, ExportBoardgameDto>();

        //Seller mapping
        this.CreateMap<ImportSellerDto, Seller>()
            .ForMember(d => d.BoardgamesSellers, opt => opt.Ignore());
    }
}