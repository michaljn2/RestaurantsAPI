using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }

        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (Kentucky Fried Chicken) is an American fast food " +
                                  "restaurant chain headquartered in Louisville, Kentucky, that specializes " +
                                  "in fried chicken.",
                    HasDelivery = true,
                    ContactEmail = "kfc@gmail.com",
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Niepodległości 11",
                        PostalCode = "02-780"
                    },
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Chicken Strips",
                            Description = "Polędwiczki kurczaka w panierce",
                            Price = 19.99M,
                        },
                        new Dish()
                        {
                            Name = "Grander",
                            Description = "Kanapka z kawałkiem kurczaka i sosem BBQ",
                            Price = 25.99M
                        },
                        new Dish()
                        {
                            Name = "Dolewka",
                            Description = "Dowolny napój z możliwością dolewania z automatu",
                            Price = 8.99M
                        }
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald's",
                    Category = "Fast Food",
                    Description = "McDonald's Corporation is an American multinational fast food " +
                                  "chain, founded in 1940 as a restaurant operated by Richard and " +
                                  "Maurice McDonald, in San Bernardino, California, United States.",
                    HasDelivery = true,
                    ContactEmail = "mcdonalds@gmail.com",
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Wałbrzyska 99",
                        PostalCode = "02-785"
                    },
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "WieśMac",
                            Description = "Kanapka z wołowiną i warzywami",
                            Price = 19.99M,
                        },
                        new Dish()
                        {
                            Name = "McWrap",
                            Description = "Tortilla z warzywami i kurczakiem",
                            Price = 21.99M
                        },
                        new Dish()
                        {
                            Name = "McFlurry",
                            Description = "Lody waniliowe z posypką",
                            Price = 8.99M
                        }
                    }
                }
            };
            return restaurants;
        }
    }
}
