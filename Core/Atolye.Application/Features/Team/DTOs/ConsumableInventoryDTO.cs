using System;
using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Team.DTOs
{
	public class ConsumableInventoryDTO : IDTO
	{
        public string? InventoryId { get; set; }
        public string? TeamId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Details { get; set; }
    }
}

