using AutoMapper;
using CwkBooking.Api.Dtos;
using CwkBooking.Domain.Abstractions.Services;
using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CwkBooking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResevrationsController : ControllerBase
    {
        private readonly IReservationService _reservationsService;
        private readonly IMapper _mapper;
        public ResevrationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationsService = reservationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationPutPostDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);
            var result = await _reservationsService.MakeReservation(reservation);

            if (result == null)
                return BadRequest("Cannot create reservation");

            return Ok(result);
        }
    }
}
