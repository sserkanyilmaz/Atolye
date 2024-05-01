using System;
using Atolye.Application.Features.Base.Commands.Add;
using Atolye.Application.Features.Base.DTOs;
using Atolye.Application.Features.Team.Commands.Add;
using Atolye.Application.Features.Team.DTOs;
using Atolye.Application.Utilities.Common;
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
        [HttpPost]
        public async Task<IActionResult> AdmdBase(AddBaseCommandRequest addBaseCommandRequest)
        {
            IDataResult<BaseDTO> response = await _mediator.Send(addBaseCommandRequest);
            return Ok(response);
        }
    }
}

