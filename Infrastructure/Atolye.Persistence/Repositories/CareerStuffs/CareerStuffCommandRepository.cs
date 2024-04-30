using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.ActivityLogs.CareerStuffs;

public class CareerStuffCommandRepository : CommandRepository<CareerStuff> , ICommandRepository<CareerStuff>
{
    public CareerStuffCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
    {
    }
}