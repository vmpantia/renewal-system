using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS.BAL.Contractors;
using RS.DAL.Contractors;
using RS.DAL.DataAccess.Entities;
using System.Linq.Expressions;

namespace RS.BAL.Services
{
    public class SubscriptionService : BaseService<Subscription>
    {
        public SubscriptionService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<TDto> GetAll<TDto>(Expression<Func<Subscription, bool>> expression = null)
        {
            var result = _repository.GetAll(expression)
                                    .Include(data => data.Customer)
                                    .Include(data => data.Product);

            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public override TDto GetOne<TDto>(Expression<Func<Subscription, bool>> expression)
        {
            var result = _repository.GetOne(expression, tbl => tbl.Customer,
                                                        tbl => tbl.Product);

            return _mapper.Map<TDto>(result);
        }
    }
}
