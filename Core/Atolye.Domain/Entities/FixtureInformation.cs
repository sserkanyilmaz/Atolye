using System;
using Atolye.Domain.Common;

namespace Atolye.Domain.Entities
{
	public class FixtureInformation : BaseEntity
    {
        public string? Content { get; set; }
        public string? ContactInfo { get; set; }
    }
}

