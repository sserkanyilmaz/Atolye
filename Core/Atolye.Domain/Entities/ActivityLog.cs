using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class ActivityLog : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }

        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}

