using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinimumCreatedRestaurantsRequirement : IAuthorizationRequirement
    {
        public int MinimumCreatedRestaurants { get; }

        public MinimumCreatedRestaurantsRequirement(int minimumCreatedRestaurants)
        {
            MinimumCreatedRestaurants = minimumCreatedRestaurants;
        }
    }
}
