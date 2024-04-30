using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Report : BaseEntity
    {
        public string? Content { get; set; }

        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}

