using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Users.Services;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Domain.BoundedContexts.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LubyClocker.Application.BoundedContexts.Users.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, AuthenticationResult>
    {
        private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;

        public SignUpCommandHandler( UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<AuthenticationResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new InvalidRequestException(MainResource.CreationError);
            }

            return await _authService.GenerateJwtToken(user.UserName);
        }
    }
}