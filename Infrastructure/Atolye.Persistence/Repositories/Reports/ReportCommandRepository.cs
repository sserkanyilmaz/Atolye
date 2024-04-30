using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Reports
{
    public class ReportCommandRepository : CommandRepository<Report> , ICommandRepository<Report>
	{
		public ReportCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

