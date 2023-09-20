using AutoMapper;
using RS.BAL.Contractors;
using RS.DAL.Contractors;
using RS.DAL.DataAccess.Entities;

namespace RS.BAL.Services
{
    public class DefinitionService : BaseService<Definition>
    {
        public DefinitionService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }
    }
}
