namespace BoatSystem.Application
{
    using BoatSystem.Core.Models;
    using MediatR;

    public class LoginCommand : IRequest<AuthModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
