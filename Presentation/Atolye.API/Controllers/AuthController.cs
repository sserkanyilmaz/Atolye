using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Atolye.Application.Features.Auth.Commands.Login;
using Atolye.Application.Utilities.Common;
using Atolye.Application.Features.Auth.Commands.Register;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atolye.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> Login(LoginPersonCommandRequest loginPersonCommandRequest)
        {
            IDataResult<LoginPersonCommandResponse> response = await _mediator.Send(loginPersonCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterPersonCommandRequest registerPersonCommandRequest)
        {
            IDataResult<RegisterPersonCommandResponse> response = await _mediator.Send(registerPersonCommandRequest);
            return Ok(response);
        }
    }
}

