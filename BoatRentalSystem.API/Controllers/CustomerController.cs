using BoatRentalSystem.Application.BoatBooking.Query;
using BoatRentalSystem.Application.City.Query;
using BoatRentalSystem.Application.Reservation.Query;
using BoatRentalSystem.Core.Interfaces;
using BoatSystem.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoatRentalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Customer)]

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public CustomerController(ICustomerRepository customerRepository,UserManager<ApplicationUser> userManager,IMediator mediator)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
            _mediator = mediator;
        }


        [HttpGet("Reservation")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetReservation()
        {
            var customerId = await _customerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);

            var query = new ListCustomerReservationQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Booking")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetBooking()
        {
            var customerId = await _customerRepository.GetIdByUserIDAsync(User.FindFirst(c => c.Type == "uid")?.Value);

            var query = new ListCustomerBoatBookingQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("WalletBalance")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetWalletBalance()
        {
            var customer = await _customerRepository.GetByUserIdAsync(User.FindFirst(c => c.Type == "uid")?.Value);

         

            if (customer == null)
            {
                return NotFound();
            }


            return Ok(customer.WalletBalance);


        }






    }
}
