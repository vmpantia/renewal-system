using AutoMapper;
using RS.BAL.Models;
using RS.Common.Extensions;
using RS.DAL.DataAccess.Entities;

namespace RS.BAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(dto => dto.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.LastName}, {src.Customer.FirstName}"))
                .ForMember(dto => dto.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dto => dto.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dto => dto.ProductDescription, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dto => dto.Status, opt => opt.MapFrom(src => src.Status.GetDescription()));
        }
    }
}
