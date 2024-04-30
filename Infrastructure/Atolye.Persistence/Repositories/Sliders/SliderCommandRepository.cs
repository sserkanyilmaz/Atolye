using System;
using Atolye.Application.Abstraction.Repository;
using Atolye.Domain.Entities;
using Atolye.Persistence.Context;

namespace Atolye.Persistence.Repositories.Sliders
{
	public class SliderCommandRepository : CommandRepository<Slider> , ICommandRepository<Slider>
	{
		public SliderCommandRepository(AtolyeDbContext atolyeDbContext) : base(atolyeDbContext)
		{
		}
	}
}

