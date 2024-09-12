using AutoMapper;
using BoatRentalSystem.Application.Boat.Command.Add;
using BoatRentalSystem.Application.Boat.Command.Update;
using BoatRentalSystem.Application.Boat.Query;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoatRentalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly BoatService _boatService;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BoatController(BoatService boatService, IMapper mapper, IMediator mediator,IOwnerRepository ownerRepository)
        {
            _boatService = boatService;
            _mapper = mapper;
            _mediator = mediator;
            _ownerRepository = ownerRepository;
            
        }



        
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new ListBoatsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetBoatQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

       [Authorize]
        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailable()
        {
            var query = new ListAvailbeBoatsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [Authorize(Roles = "owner")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddBoatDto boat)
        {

            if (boat == null )
            {
                return BadRequest(ModelState);
            }

            AddBoatCommand command=new AddBoatCommand(boat);

            command.Boat.OwnerId= await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("status")]
        public async Task<ActionResult> UpdateBoatStatus(VerifyBoatCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest("error in update boat");
            }
            return Ok(result);
        }

        




    }
}
