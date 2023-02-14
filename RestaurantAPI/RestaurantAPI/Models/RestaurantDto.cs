using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace RestaurantAPI.Models
{
    // tutaj bez maila i numeru kontaktowego (zakladamy, że klient ma ich nie znac)
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public List<DishDto> Dishes { get; set; }
    }
}
