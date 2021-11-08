using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CwkBooking.Api.Controllers
{
    
    // /hotels
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : Controller
    {
        public HotelsController()
        {

        }

        // will execute on Get
        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok("Hello from hotels controller");
        }
    }
}
