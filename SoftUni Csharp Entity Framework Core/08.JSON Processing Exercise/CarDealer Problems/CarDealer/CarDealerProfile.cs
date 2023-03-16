namespace CarDealer;

using System.Globalization;

using Models;
using AutoMapper;
using DTOs.Import;
using DTOs.Export;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<ImportSupplierDto, Supplier>();

        CreateMap<ImportPartDto, Part>();

        CreateMap<ImportCarDto, Car>();

        CreateMap<ImportCustomerDto, Customer>();

        CreateMap<ImportSaleDto, Sale>();

        CreateMap<Customer, ExportCustomerDto>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

        CreateMap<Car, ExportToyotaCarDto>();

        CreateMap<Supplier, ExportLocalSupplierDto>()
            .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));
    }
}