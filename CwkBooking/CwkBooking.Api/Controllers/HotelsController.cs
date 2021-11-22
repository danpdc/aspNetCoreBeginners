using CwkBooking.Api.Services;
using CwkBooking.Api.Services.Abstractions;
using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly MyFirstService _firstService;
        private readonly ISingletonOperation _singleton;
        private readonly ITransientOperation _transient;
        private readonly IScopedOperation _scoped;
        private readonly ILogger<HotelsController> _logger;
        public HotelsController(MyFirstService service, ISingletonOperation singleton,
            ITransientOperation transient, IScopedOperation scoped, ILogger<HotelsController> logger)
        {
            _firstService = service;
            _singleton = singleton;
            _transient = transient;
            _scoped = scoped;
            _logger = logger;   
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            _logger.LogInformation($"GUID of singleton: {_singleton.Guid}");
            _logger.LogInformation($"GUID of transient: {_transient.Guid}");
            _logger.LogInformation($"GUID of scoped: {_scoped.Guid}");

            var hotels = _firstService.GetHotels();
            return Ok(hotels);
        }


        [Route("{id}")]
        [HttpGet]       
        public IActionResult GetHotelById(int id)
        {
            var hotels = _firstService.GetHotels();
            var hotel = hotels.FirstOrDefault(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var hotels = _firstService.GetHotels();
            hotels.Add(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelId}, hotel);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateHotel([FromBody] Hotel updated, int id)
        {
            var hotels = _firstService.GetHotels();
            var old = hotels.FirstOrDefault(h => h.HotelId == id);

            if (old == null)
                return NotFound("No resource with the corresponding ID found");

            hotels.Remove(old);
            hotels.Add(updated);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotels = _firstService.GetHotels();
            var toDelete = hotels.FirstOrDefault(h => h.HotelId == id);

            if (toDelete == null)
                return NotFound("No resource found with the provided ID");

            hotels.Remove(toDelete);
            return NoContent();
        }       
    }
}
