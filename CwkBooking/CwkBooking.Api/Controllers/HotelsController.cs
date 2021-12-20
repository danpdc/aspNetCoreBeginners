using AutoMapper;
using CwkBooking.Api.Dtos;
using CwkBooking.Dal;
using CwkBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CwkBooking.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        public HotelsController(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _ctx.Hotels.ToListAsync();
            var hotelsGet = _mapper.Map<List<HotelGetDto>>(hotels);

            return Ok(hotelsGet);
        }


        [Route("{id}")]
        [HttpGet]       
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            var hotelGet = _mapper.Map<HotelGetDto>(hotel);
            return Ok(hotelGet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelCreateDto hotel)
        {
            var domainHotel = _mapper.Map<Hotel>(hotel);
            
            _ctx.Hotels.Add(domainHotel);
            await _ctx.SaveChangesAsync();

            var hotelGet = _mapper.Map<HotelGetDto>(domainHotel);
            
            return CreatedAtAction(nameof(GetHotelById), new { id = domainHotel.HotelId}, hotelGet);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelCreateDto updated, int id)
        {
            var toUpdate = _mapper.Map<Hotel>(updated);
            toUpdate.HotelId = id;

            _ctx.Hotels.Update(toUpdate);
            await _ctx.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return NotFound();

            _ctx.Hotels.Remove(hotel);
            await _ctx.SaveChangesAsync();
            
            return NoContent();
        }
        
        [HttpGet]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> GetAllHotelRooms(int hotelId)
        {
            var rooms = await _ctx.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
            var mappedRooms = _mapper.Map<List<RoomGetDto>>(rooms);

            return Ok(mappedRooms);
        }

        [HttpGet]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> GetHotelRoomById(int hotelId, int roomId)
        {
            var room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.HotelId == hotelId && r.RoomId == roomId);
            if (room == null)
                return NotFound("Room not found");

            var mappedRoom = _mapper.Map<RoomGetDto>(room);

            return Ok(mappedRoom);
        }

        [HttpPost]
        [Route("{hotelId}/rooms")]
        public async Task<IActionResult> AddHotelRoom(int hotelId, [FromBody] RoomPostPutDto newRoom)
        {
            var room = _mapper.Map<Room>(newRoom);
            //room.HotelId = hotelId;

            //_ctx.Rooms.Add(room);
            //await _ctx.SaveChangesAsync();

            var hotel = await _ctx.Hotels.Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == hotelId);

            hotel.Rooms.Add(room);

            await _ctx.SaveChangesAsync();

            var mappedRoom = _mapper.Map<RoomGetDto>(room);

            return CreatedAtAction(nameof(GetHotelRoomById), 
                new { hotelId = hotelId, roomId = mappedRoom.RoomId}, mappedRoom);
        }

        [HttpPut]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> UpdateHotelRoom(int hotelId, int roomId, 
            [FromBody] RoomPostPutDto updatedRoom)
        {
            var toUpdate = _mapper.Map<Room>(updatedRoom);
            toUpdate.RoomId = roomId;
            toUpdate.HotelId = hotelId;

            _ctx.Rooms.Update(toUpdate);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{hotelId}/rooms/{roomId}")]
        public async Task<IActionResult> RemoveRoomFromHotel(int hotelId, int roomId)
        {
            var room = await _ctx.Rooms.SingleOrDefaultAsync(r => r.RoomId == roomId && r.HotelId == hotelId);

            if (room == null)
                return NotFound("Room not found");

            _ctx.Rooms.Remove(room);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
