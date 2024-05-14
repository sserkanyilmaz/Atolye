using System;
using Atolye.Application.Abstraction.DTOs;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Domain.Entities;

namespace Atolye.Application.Features.Base.DTOs
{
    public class GetBaseDto : IDTO
    {

        public string? BaseId { get; set; }
        public string? Name { get; set; }
        public List<TeamDTO>? Teams { get; set; }

        public List<BaseImageDTO>? Images { get; set; }

        public List<FixtureInventoryDTO>? FixtureInventories { get; set; }

        public List<CareerStuffDTO>? CareerStuffs { get; set; }
        
        public Guid? FixtureInformationId { get; set; }
        public FixtureInformationDTO?  FixtureInformation { get; set; }

        public List<BaseNewDTO>? BaseNews { get; set; }

        public List<ActivityLogDTO>? ActivityLogs { get; set; }
    }
}

