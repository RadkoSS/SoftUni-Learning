namespace CarDealer;

using AutoMapper;

using Models;
using DTOs.Import;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<Supplier, ImportSupplierDto>();
        CreateMap<ImportSupplierDto, Supplier>();

        CreateMap<Part, ImportPartDto>();
        CreateMap<ImportPartDto, Part>();

        CreateMap<Car, ImportCarDto>();
        CreateMap<ImportCarDto, Car>();
    }
}