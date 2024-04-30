using Atolye.Application.Abstraction.DTOs;

namespace Atolye.Application.Features.Base.DTOs
{
    public class FixtureInventoryDTO : IDTO
    {
        public string? InventoryId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Details { get; set; }
    }
}