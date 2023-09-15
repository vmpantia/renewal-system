using AutoMapper;
using RS.DAL.Contractors;
using System.Linq.Expressions;

namespace RS.BAL.Contractors
{
    public class BaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TEntity> _repository;
        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = _uow.GetRepository<TEntity>();
        }

        public virtual IEnumerable<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> expression = null)
        {
            var result = _repository.GetAll(expression);
            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public virtual TDto GetOne<TDto>(Expression<Func<TEntity, bool>> expression)
        {
            var result = _repository.GetOne(expression);
            return _mapper.Map<TDto>(result);
        }
    }
}
