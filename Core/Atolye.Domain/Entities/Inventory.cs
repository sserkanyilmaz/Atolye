using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Inventory: BaseEntity
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Details { get; set; }
    }
}

