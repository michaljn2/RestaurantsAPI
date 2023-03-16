using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace RestaurantAPI.Services
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? GetUserId { get; }
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // przekazujemy Usera z httpContext (?, bo niektóre endpointy nie wymagaja autoryzacji, wtedy usera nie ma)
        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
        // tak samo tu jezeli nie ma Usera, to jego id bedzie nullem
        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
