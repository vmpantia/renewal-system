using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS.BAL.Contractors;
using RS.DAL.Contractors;
using RS.DAL.DataAccess.Entities;
using System.Linq.Expressions;

namespace RS.BAL.Services
{
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<TDto> GetAll<TDto>(Expression<Func<Customer, bool>> expression = null)
        {
            var result = _repository.GetAll(expression)
                                    .Include(data => data.Subscriptions);

            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public override TDto GetOne<TDto>(Expression<Func<Customer, bool>> expression)
        {
            var result = _repository.GetOne(expression, tbl => tbl.Subscriptions);

            return _mapper.Map<TDto>(result);
        }
    }
}
