namespace BoatSystem.API.Controllers
{
    using BoatRentalSystem.Application;
    using BoatSystem.Application;
    using BoatSystem.Core.Interfaces;
    using BoatSystem.Core.Models;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly IMediator _mediator;
        public AuthController(IAuthService authService , IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }



        [HttpPost("register-owner")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Owner)]
        public async Task<IActionResult> RegisterOwner(RegisterOwnerCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("register-customer")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Customer)]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }



        [HttpPost("verify-owner")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Admin)]
        public async Task<IActionResult> VerifyOwner(VerifyOwnerCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

       




    }
}
