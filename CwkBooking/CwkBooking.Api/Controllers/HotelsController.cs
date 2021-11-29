using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CwkBooking.Api.Controllers
{
    
    //CRUD
    //Create
    //Read - get all, get by id
    //Update
    //Delete
    // /hotels
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly ILogger<HotelsController> _logger;
        private readonly HttpContext _http;
        public HotelsController(ILogger<HotelsController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _http = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            HttpContext.Request.Headers.TryGetValue("my-middleware-header", out var headerDate);
            return Ok(headerDate);
        }


        [Route("{id}")]
        [HttpGet]       
        public IActionResult GetHotelById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            return NoContent();
        }       
    }
}
