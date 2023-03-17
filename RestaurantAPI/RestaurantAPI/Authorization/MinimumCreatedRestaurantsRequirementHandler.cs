using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Authorization
{
    public class MinimumCreatedRestaurantsRequirementHandler : AuthorizationHandler<MinimumCreatedRestaurantsRequirement>
    {
        private readonly ILogger<MinimumCreatedRestaurantsRequirementHandler> _logger;
        private readonly RestaurantDbContext _context;

        public MinimumCreatedRestaurantsRequirementHandler(ILogger<MinimumCreatedRestaurantsRequirementHandler> logger, 
            RestaurantDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumCreatedRestaurantsRequirement requirement)
        {
            int userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            int restaurantsCreatedByUserCounter = _context.Restaurants
                .Count(r => r.CreatedById == userId);

            if (restaurantsCreatedByUserCounter >= requirement.MinimumCreatedRestaurants)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
