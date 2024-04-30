using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class EngineerOfTheMonth : BaseEntity
	{
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public DateTime Month { get; set; }
        public string? AchievementDetails { get; set; }
    }
}

