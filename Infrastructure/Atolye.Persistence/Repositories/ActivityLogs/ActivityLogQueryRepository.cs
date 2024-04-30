using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.ActivityLogs
{
    public class ActivityLogQueryRepository : QueryRepository<ActivityLog> , IQueryRepository<ActivityLog>
    {
        public ActivityLogQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
        {
        }
    }
}
