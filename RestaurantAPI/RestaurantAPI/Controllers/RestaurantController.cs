using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult <IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantDtos = _service.GetAll();
            return Ok(restaurantDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _service.GetById(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = _service.Create(dto);
            // przekazujemy odpowiedz Created wraz ze sciezka pod ktora bedzie dostepny utworzony zasób
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]

        public ActionResult UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _service.Update(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
