using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Images
{
	public class ImageCommandRepository : CommandRepository<Image> , ICommandRepository<Image>
	{
		public ImageCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

