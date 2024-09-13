using AutoMapper;
using BoatRentalSystem.Application.BoatBooking.Command.Add;
using BoatRentalSystem.Application.BoatBooking.Command.Update;
using BoatRentalSystem.Application.BoatBooking.Query;
using BoatRentalSystem.Application.BoatBooking.ViewModels;
using BoatRentalSystem.Application.Payment.Command;
using BoatRentalSystem.Application.Reservation.Command.Add;
using BoatRentalSystem.Application.Reservation.Command.Update;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatRentalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BoatService _boatService;
        private readonly BoatBookingService _boatBookingService;
        private readonly IMediator _mediator;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public BookingController(BoatService boatService, BoatBookingService boatBookingService, IMapper mapper, IMediator mediator, ICustomerRepository customerRepository, IOwnerRepository ownerRepository)
        {
            _boatService = boatService;
            _boatBookingService = boatBookingService;
            _mapper = mapper;
            _mediator = mediator;
            _customerRepository = customerRepository;
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get()
        {
            var query = new ListBoatBookingsQuery   ();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetBoatBookingQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] AddBoatBookingDto boatBooking)
        {

            if (boatBooking == null)
            {
                return BadRequest();
            }

            var boatBookingCommand = new AddBoatBookingCommand(boatBooking);
            var result = await _mediator.Send(boatBookingCommand);

            return Ok(result);

        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateBoatBookingDto boatBookingDto)
        {
            var command = new UpdateBoatBookingCommand(boatBookingDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{boatBookingId}/UpdateStatus")]
        [Authorize(Roles = "owner")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateStatus(int boatBookingId, BoatBookingStatus boatBookingStatus)
        {
            var command = new UpdateBoatBookingStatusCommand(boatBookingStatus, boatBookingId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{bookingId}/Payment")]
        [Authorize]
        public async Task<IActionResult> Payment(int bookingId)
        {
            var command = new AddBoatBookingPaymentCommand(bookingId);

            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }




        }

        [HttpPost("{bookingId}/Cancel")]
       [Authorize]
        public async Task<IActionResult> CancelReservation(int bookingId)
        {
            var command = new CancelBoatBookingCommand(bookingId);
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

        }



    }
}
