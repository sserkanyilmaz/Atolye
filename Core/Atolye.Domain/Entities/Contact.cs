using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class Contact : BaseEntity
	{
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
	}
}

