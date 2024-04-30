using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.ActivityLogs
{
    public class ActivityLogCommandRepository : CommandRepository<ActivityLog> , ICommandRepository<ActivityLog>
    {
        public ActivityLogCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
        {
        }
    }
}
