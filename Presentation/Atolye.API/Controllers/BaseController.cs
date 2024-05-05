using System;
using Atolye.Application.Features.Base.Commands.Add;
using Atolye.Application.Features.Base.Commands.AddActivityLogToBase;
using Atolye.Application.Features.Base.Commands.AddBaseInformation;
using Atolye.Application.Features.Base.Commands.AddFixtureInventoryToBase;
using Atolye.Application.Features.Base.Commands.AddImageToBase;
using Atolye.Application.Features.Base.Commands.AddTeamToBase;
using Atolye.Application.Features.Base.Commands.DeleteImageFromBase;
using Atolye.Application.Features.Base.Commands.DeleteTeamFrom;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Base.Queryies.GetBase;
using Atolye.Application.Features.Team.Commands.Add;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
using Atolye.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Atolye.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBase()
        {
            IDataResult<GetBaseDto> response = await _mediator.Send(new GetBaseQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddBase(AddBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddTeamToBase(AddTeamToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteTeamFromBase(DeleteTeamFromBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddImageToBase(AddImageToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteImageFromBase(DeleteImageFromBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddActivityLogToBase(AddActivityLogToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddFixtureInventoryToBase(AddFixtureInventoryToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> AddBaseNewsToBase(AddBaseNewsToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteBaseNewsFromBase(DeleteBaseNewsFromBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddCareerStuffToBase(AddCareerStuffToBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> DeleteCareerStuffFromBase(DeleteCareerStuffFromBaseCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AddBaseInformation(AddBaseInformationCommandRequest request)
        {
            IDataResult<BaseDto> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

