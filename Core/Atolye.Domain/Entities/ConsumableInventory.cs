using System;
namespace Atolye.Domain.Entities
{
	public class ConsumableInventory : Inventory 
	{
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }
    }
}

