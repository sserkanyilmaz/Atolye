using System;
namespace Atolye.Domain.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public bool IsActive { get; set; }
	}
}

