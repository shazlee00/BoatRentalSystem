using BoatRentalSystem.Core.Interfaces;
using BoatSystem.Core.Models;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(ICustomerRepository customerRepository,UserManager<ApplicationUser> userManager)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var userId=User.FindFirst(c=> c.Type == "uid")?.Value;

            


            // Get user email
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            // Get user name
            var userName = User.Identity.Name; // This could also be from ClaimTypes.Name

            // Check if user is authenticated
            var isAuthenticated = User.Identity.IsAuthenticated;

            var customer=await _customerRepository.GetByUserIdAsync(userId);

            return Ok(
                new
                {
                   userId,
                   userEmail,
                   userName,
                   isAuthenticated,
                   customer
                }
                );



        }
    }
}
