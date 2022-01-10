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


            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.IdCustomer, opts => opts.MapFrom(src => src.IdCustomer)).ReverseMap()
            .ForMember(dest => dest.IdTypePayment, opts => opts.MapFrom(src => src.IdTypePayment)).ReverseMap()
             .ForMember(dest => dest.IdTypeDelivery, opts => opts.MapFrom(src => src.IdTypeDelivery)).ReverseMap()
            .ForMember(dest => dest.IdAddressDelivery, opts => opts.MapFrom(src => src.IdAddressDelivery)).ReverseMap()
            .ForMember(dest => dest.OrderDeliveryPrice, opts => opts.MapFrom(src => src.OrderDeliveryPrice)).ReverseMap()
            .ForMember(dest => dest.Itens, opts => opts.MapFrom(src => src.Itens)).ReverseMap();


            CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.IdProduct, opts => opts.MapFrom(src => src.IdProduct)).ReverseMap()
            .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Quantity)).ReverseMap()
            .ForMember(dest => dest.UnitPrice, opts => opts.MapFrom(src => src.UnitPrice)).ReverseMap();

        }
    }
}
