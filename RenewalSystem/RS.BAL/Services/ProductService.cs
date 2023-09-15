using AutoMapper;
using RS.BAL.Contractors;
using RS.DAL.Contractors;
using RS.DAL.DataAccess.Entities;

namespace RS.BAL.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
    }
}
