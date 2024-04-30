using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.News
{
	public class NewsCommandRepository : CommandRepository<Domain.Entities.BaseNew> , ICommandRepository<Domain.Entities.BaseNew>
	{
		public NewsCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
} 

