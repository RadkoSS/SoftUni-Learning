namespace CarDealer;

using AutoMapper;
using System.Globalization;

using Models;
using DTOs.Export;
using DTOs.Import;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier
        this.CreateMap<ImportSupplierDto, Supplier>();

        //Part
        this.CreateMap<ImportPartDto, Part>();

        //Car
        this.CreateMap<ImportCarDto, Car>()
            .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

        this.CreateMap<Car, ExportCarDto>();
        this.CreateMap<Car, ExportBmwCarDto>();

        //Customer
        this.CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        //Sale
        this.CreateMap<ImportSaleDto, Sale>();
    }
}