namespace CarDealer;

using System.Globalization;
using AutoMapper;
using DTOs.Import;
using Models;

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

        //Customer
        this.CreateMap<ImportCustomerDto, Customer>()
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

        //Sale
        this.CreateMap<ImportSaleDto, Sale>();
    }
}