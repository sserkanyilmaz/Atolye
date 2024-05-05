using Atolye.Application.Abstraction.Repository;

namespace Atolye.Application.Features.Base.Rules;

public class BaseBussinessRules
{
    private IQueryRepository<Domain.Entities.Base> _queryRepository;
    public BaseBussinessRules(IQueryRepository<Domain.Entities.Base> queryRepository)
    {
        _queryRepository = queryRepository;
    }
}