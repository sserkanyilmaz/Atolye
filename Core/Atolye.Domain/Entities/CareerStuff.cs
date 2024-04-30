using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class CareerStuff : BaseEntity
    {
        public ICollection<BaseNew>? News { get; set; }
        public ICollection<Image>? Images { get; set; }
    }
}

