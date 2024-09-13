using AutoMapper;
using BoatRentalSystem.Application.Boat.Command.Add;
using BoatRentalSystem.Application.Boat.Command.Update;
using BoatRentalSystem.Application.Boat.Query;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Application.BoatBooking.Query;
using BoatRentalSystem.Application.Reservation.Query;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure.Repositories;
using BoatSystem.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatRentalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Customer)]
    public class OwnerController : ControllerBase
    {
        private readonly BoatService _boatService;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OwnerController(BoatService boatService, IMapper mapper, IMediator mediator, IOwnerRepository ownerRepository)
        {
            _boatService = boatService;
            _mapper = mapper;
            _mediator = mediator;
            _ownerRepository = ownerRepository;

        }


        [HttpGet("{ownerId}/boat")]
       [Authorize(Roles = "owner")]
        public async Task<IActionResult> GetBoatsByOwnerId(int ownerId)
        {
            var currentownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);

            if (currentownerId != ownerId)
            {
                return Forbid("You are not authorized to update this boat.");
            }

            var query = new ListOwnerBoatsQuery(ownerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }



        [HttpGet("{ownerId}/boat/{boatId}")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> GetBoatById(int ownerId, int boatId)
        {
            var currentownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);
            if (currentownerId != ownerId)
            {
                return Forbid();
            }
            var query = new GetBoatQuery(boatId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }



        [HttpPost("{ownerId}/boat")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> Post(int ownerId, [FromBody] AddBoatCommand command)
        {
            var currentownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);
            if (currentownerId != ownerId)
            {
                return Forbid();
            }
            command.Boat.OwnerId = ownerId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{OwnerId}/boat")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> UpdateBoatStatus(int ownerId,[FromBody] UpdateBoatDto boat)
        {


            var command = new UpdateBoatCommand(boat,ownerId);

            var currentownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);

            if (currentownerId != ownerId)
            {
                return Forbid();
            }

            command.UpdateBoatDto.OwnerId = ownerId;


            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{ownerId}/boat")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> DeleteBoat(int ownerId,int boatId)
        {
            var currentownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);
            var boat = await _boatService.GetBoatById(boatId);
            if (currentownerId != ownerId)
            {
                return Forbid();
            }

            if (boat == null)
            {
                return NotFound();
            }

            if (boat.OwnerId != ownerId)
            {
                return Forbid();
            }
            await _boatService.DeleteBoat(boatId);
            return NoContent();
        }

        [HttpGet("Reservation")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> GetOwnerReservation()
        {
            var ownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);
            var query = new ListOwnerReservationQuery(ownerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Booking")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> GetOwnerBooking()
        {
            var ownerId = await _ownerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);
            var query = new ListOwnerBoatBookingQuery(ownerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("WalletBalance")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> GetWalletBalance()
        {
            var customer = await _ownerRepository.GetByUserIdAsync(User.FindFirst(c => c.Type == "uid")?.Value);



            if (customer == null)
            {
                return NotFound();
            }


            return Ok(customer.WalletBalance);


        }


    }
}