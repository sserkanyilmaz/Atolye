using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Base : BaseEntity
	{
		public string? Name { get; set; }

		public List<Team>?  Teams { get; set; }

		public List<Image>? Images { get; set; }

		public List<FixtureInventory>? fixtureInventories { get; set; }


		public Guid? FixtureInformationId { get; set; }
		public FixtureInformation? FixtureInformation { get; set; }

		public List<BaseNew>? BaseNews { get; set; }

		public List<ActivityLog>? ActivityLogs { get; set; }

		public Guid? ContactId { get; set; }
		public Contact? Contact { get; set; }


	}
}

