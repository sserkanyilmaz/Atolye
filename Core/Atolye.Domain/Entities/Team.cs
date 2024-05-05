using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Team : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Person>? Members { get; set; }

        public Guid? ProjectId { get; set; }
        public Project? Project { get; set; }

        public Guid? BaseId { get; set; }
        public Base? Base { get; set; }

        public string? Achievements { get; set; }
        public string? History { get; set; }

        public ICollection<Image>? Images { get; set; }

        public ICollection<ConsumableInventory>? ConsumableInventory { get; set; }

        public ICollection<Report>? Reports { get; set; }
    }
    
}

