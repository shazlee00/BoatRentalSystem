using AutoMapper;
using BoatRentalSystem.Application.Payment.Command;
using BoatRentalSystem.Application.Reservation.Command.Add;
using BoatRentalSystem.Application.Reservation.Command.Update;
using BoatRentalSystem.Application.Reservation.Query;
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

    public class ReservationController : ControllerBase
    {
        private readonly TripService _tripService;
        private readonly ReservationService _reservationService;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReservationController(ReservationService reservationService,TripService tripService, IMapper mapper, IMediator mediator, ICustomerRepository customerRepository, IOwnerRepository ownerRepository)
        {
            _tripService = tripService;
            _mapper = mapper;
            _mediator = mediator;
            _customerRepository = customerRepository;
            _ownerRepository = ownerRepository;
            _reservationService = reservationService;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get()
        {
            var query = new ListReservationsQuery();
            var result = await _mediator.Send(query);
          
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetReservationQuery(id);
            var resView = await _mediator.Send(query);
            if (resView == null) { return BadRequest(); }
            return Ok(resView);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] AddReservationDto reservation)
        {

            if (reservation == null)
            {
                return BadRequest();
            }

            var reservationCommand=new AddReservationCommand(reservation);
            var result = await _mediator.Send(reservationCommand);

            return Ok(result);       

        }



        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateReservationDto reservation)
        {
            var command = new UpdateReservationCommand(reservation);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{reservationId}/UpdateStatus")]
        [Authorize(Roles = "owner")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateStatus(int reservationId, ReservationStatus reservationStatus)
        {
            var command = new UpdateReservationStatusCommand(reservationStatus, reservationId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{reservationId}/Payment")]
       // [Authorize]
        public async Task<IActionResult> Payment(int reservationId)
        {
            var command = new AddReservationPaymentCommand(reservationId);
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

        [HttpPost("{reservationId}/Cancel")]
        [Authorize]
        public async Task<IActionResult> CancelReservation(int reservationId)
        {
            var command = new CancelReservationCommand(reservationId);
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
