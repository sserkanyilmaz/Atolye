using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.FixtureInformations
{
	public class FixtureInformationCommandRepository : CommandRepository<FixtureInformation>, ICommandRepository<FixtureInformation>
	{
		public FixtureInformationCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

