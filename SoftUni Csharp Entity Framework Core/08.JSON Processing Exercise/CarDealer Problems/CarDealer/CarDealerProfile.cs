namespace CarDealer;

using AutoMapper;

using Models;
using DTOs.Import;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<Supplier, ImportSuppliersDto>();
        CreateMap<ImportSuppliersDto, Supplier>();

        CreateMap<Part, ImportPartsDto>();
        CreateMap<ImportPartsDto, Part>();
    }
}