using AutoMapper;
using POC_GITHUB_06012022.v1.Entity;
using POC_GITHUB_06012022.v1.EntityDTO;

namespace POC_GITHUB_06012022.v1.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.NameProduct, opts => opts.MapFrom(src => src.NameProduct)).ReverseMap();


            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.NameCustomer, opts => opts.MapFrom(src => src.NameCustomer)).ReverseMap()
                .ForMember(dest => dest.IdStateCustomer, opts => opts.MapFrom(src => src.IdStateCustomer)).ReverseMap();

            CreateMap<CustomerAddress, CustomerAddressDto>()
                .ForMember(dest => dest.IdCustomer, opts => opts.MapFrom(src => src.IdCustomer)).ReverseMap()
                .ForMember(dest => dest.StreetName, opts => opts.MapFrom(src => src.StreetName)).ReverseMap()
                .ForMember(dest => dest.StateName, opts => opts.MapFrom(src => src.StateName)).ReverseMap()
                .ForMember(dest => dest.CityName, opts => opts.MapFrom(src => src.CityName)).ReverseMap()
                .ForMember(dest => dest.StateName, opts => opts.MapFrom(src => src.StateName)).ReverseMap()
                .ForMember(dest => dest.ZipCode, opts => opts.MapFrom(src => src.ZipCode)).ReverseMap()
                ;


        }
    }
}
