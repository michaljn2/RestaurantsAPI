using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    // interface IAuthorizationRequirement nie posiada żadnej metody, to tylko taki 'marker'
    // dla ASP.NET do rozpoznania requirementu
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get;} // usuwamy setter

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
}
