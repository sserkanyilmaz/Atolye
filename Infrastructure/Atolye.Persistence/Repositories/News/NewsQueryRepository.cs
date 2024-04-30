using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.News
{
	public class NewsQueryRepository :QueryRepository<Domain.Entities.BaseNew> , IQueryRepository<Domain.Entities.BaseNew>
	{
		public NewsQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

