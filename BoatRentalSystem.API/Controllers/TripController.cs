using AutoMapper;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Application.Trip.Command.Add;
using BoatRentalSystem.Application.Trip.Command.Update;
using BoatRentalSystem.Application.Trip.Query;
using BoatRentalSystem.Application.Trip.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using BoatSystem.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatRentalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly TripService _tripService;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TripController(TripService tripService, IMapper mapper, IMediator mediator, IOwnerRepository ownerRepository)
        {
            _tripService = tripService;
            _mapper = mapper;
            _mediator = mediator;
            _ownerRepository = ownerRepository;

        }


       [HttpGet]
       [Authorize]
        public async Task<IActionResult> Get()
        {
            var query = new ListTripsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("available-trips")]
        [Authorize]
        public async Task<IActionResult> GetAvailableTrips()
        {
            var query = new ListAvailbeTripsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
       [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTripQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
       [Authorize(Roles = "owner")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Owner)]
        public async Task<IActionResult> Post([FromBody] AddTripDto trip)
        {
            var command = new AddTripCommand(trip);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
       [Authorize(Roles = "owner")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Owner)]
        public async Task<IActionResult> Put([FromBody] UpdateTripDto trip)
        {
            var command = new UpdateTripCommand(trip);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


       [HttpDelete]
       [Authorize(Roles = "owner")]
        [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Owner)]
        public async Task<IActionResult> Delete(int id)
        {
           var trip = await _tripService.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }
            await _tripService.DeleteTrip(id);
          
            return NoContent();
        }

    }
}
