using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.FixtureInformations
{
	public class FixtureInformationQueryRepository : QueryRepository<FixtureInformation> , IQueryRepository<FixtureInformation>
	{
		public FixtureInformationQueryRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

