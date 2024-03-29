﻿using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    // sprawdza automatycznie poprawnosc modelu danych (wyslanych przez klienta) czyli ModelState.Valid
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }
        [HttpGet]
        // nazwa polityki musi pokrywac sie z ta ze Startup
        //[Authorize(Policy = "Atleast20")]
        //[Authorize(Policy = "CreatedAtLeast2Restaurants")]
        public ActionResult <PageResult<RestaurantDto>> GetAll([FromQuery] RestaurantQuery query)
        {
            var restaurantDtos = _service.GetAll(query);
            return Ok(restaurantDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _service.GetById(id);
            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // w tokenie musi byc jako Claim nazwa roli
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            int userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            int id = _service.Create(dto);

            // przekazujemy odpowiedz Created wraz ze sciezka pod ktora bedzie dostepny utworzony zasób
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant([FromRoute] int id)
        {
            _service.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantDto dto)
        {
            _service.Update(id, dto);

            return Ok();

        }
    }
}
