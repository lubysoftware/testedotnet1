using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Users.Services;
using LubyClocker.Application.BoundedContexts.Users.ViewModels;
using LubyClocker.CrossCuting.Shared;
using LubyClocker.CrossCuting.Shared.Exceptions;
using LubyClocker.Domain.BoundedContexts.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LubyClocker.Application.BoundedContexts.Users.Queries.FindUser
{
    public class FindUserQueryHandler : IRequestHandler<FindUserQuery, UserViewModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FindUserQueryHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserViewModel> Handle(FindUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _userManager.FindByIdAsync(userId);

            return new UserViewModel()
            {
                Id = result.Id,
                Email = result.Email
            };
        }
    }
}