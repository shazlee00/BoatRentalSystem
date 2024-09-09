using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatSystem.Application;
using BoatSystem.Core.Interfaces;
using BoatSystem.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application
{
    public class RegisterCustomerCommand:ICommand<AuthModel>
    {
        public CustomerRegisterModel Model { get; set; }
        public RegisterCustomerCommand(CustomerRegisterModel model)
        {
            Model = model;
        }
    }


    public class RegisterCustomerCommanHandler : ICommandHandler<RegisterCustomerCommand, AuthModel>
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerRepository _customerRepository;

        public RegisterCustomerCommanHandler(UserManager<ApplicationUser> userManager, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _customerRepository = customerRepository;
        }



        public async Task<AuthModel> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var model=request.Model;

            if(await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return new AuthModel { Message = "Email is already registered" };
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                return new AuthModel { Message = "UserName is already registered" };
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            { 
            
                return new AuthModel { Message = string.Join(", ", result.Errors.Select(e => e.Description)) };
            }

            await _userManager.AddToRoleAsync(user, "Customer");
            var customer = new Customer
            {
                UserId = user.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };
            await _customerRepository.AddAsync(customer);

            return new AuthModel { Message = "Registration Successful" };



        }

    }


    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly ICustomerRepository _customerRepository;

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, IAuthService authService, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _authService = authService;
            _customerRepository = customerRepository;
        }



        public async Task<AuthModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                authModel.Message = "Email or password is incorrect";

            }

            var userToken = await _authService.CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(userToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = userToken.ValidTo;
            authModel.Roles = roleList.ToList();

            return authModel;



        }
    }











    }






