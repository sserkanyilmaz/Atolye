using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Slider : BaseEntity
	{
		public ICollection<Image>? Images { get; set; }
	}
}

