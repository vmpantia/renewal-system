using AutoMapper;
using RS.BAL.Models;
using RS.DAL.DataAccess.Entities;

namespace RS.BAL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Subscription, SubscriptionDto>();
        }
    }
}
