using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _service;

        public DishController(IDishService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var dishId = _service.Create(restaurantId, dto);
            return Created($"api/restaurant/{restaurantId}/dish/{dishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int dishId, [FromRoute] int restaurantId)
        {
            var dishDto = _service.GetById(dishId, restaurantId);
            return Ok(dishDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var dishes = _service.GetAll(restaurantId);
            return Ok(dishes);
        }
    }
}
