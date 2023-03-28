namespace Trucks;

using AutoMapper;

using Data.Models;
using Data.Models.Enums;
using DataProcessor.ExportDto;
using DataProcessor.ImportDto;

public class TrucksProfile : Profile
{
    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public TrucksProfile()
    {
        this.CreateMap<ImportDespatcherTrucksDto, Truck>()
            .ForMember(d => d.CategoryType, opt => opt.MapFrom(s => (CategoryType) s.CategoryType))
            .ForMember(d => d.MakeType, opt => opt.MapFrom(s => (MakeType) s.MakeType));

        this.CreateMap<ImportClientDto, Client>()
            .ForMember(d => d.ClientsTrucks, opt => opt.Ignore());

        this.CreateMap<ImportDespatcherDto, Despatcher>()
            .ForMember(d => d.Trucks, opt => opt.Ignore());

        this.CreateMap<Truck, ExportTruckDto>()
            .ForMember(d => d.MakeType, opt => opt.MapFrom(s => Enum.GetName(s.MakeType)));

        this.CreateMap<Despatcher, ExportDespatchersAndTrucksDto>()
            .ForMember(d => d.TrucksCount, opt => opt.MapFrom(s => s.Trucks.Count))
            .ForMember(d => d.Trucks, opt => opt.MapFrom(s => s.Trucks.OrderBy(t => t.RegistrationNumber)));
    }
}