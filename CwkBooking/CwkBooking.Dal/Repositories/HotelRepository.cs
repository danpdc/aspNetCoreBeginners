using CwkBooking.Domain.Abstractions.Repositories;
using CwkBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CwkBooking.Dal.Repositories
{
    public class HotelRepository : IHotelsRepository
    {
        private readonly DataContext _ctx;
        public HotelRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            _ctx.Hotels.Add(hotel);
            await _ctx.SaveChangesAsync();
            return hotel;
        }

        public async Task<Room> CreateHotelRoomAsync(int hotelId, Room room)
        {
            var hotel = await _ctx.Hotels.Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == hotelId);

            hotel.Rooms.Add(room);

            await _ctx.SaveChangesAsync();
            return room;
        }

        public async Task<Hotel> DeleteHotelAsync(int id)
        {
            var hotel = await _ctx.Hotels.FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return null;

            _ctx.Hotels.Remove(hotel);
            await _ctx.SaveChangesAsync();
            return hotel;
        }

        public async Task<Room> DeleteHotelRoomAsync(int hotelId, int roomId)
        {
            var room = await _ctx.Rooms.SingleOrDefaultAsync(r => r.RoomId == roomId && r.HotelId == hotelId);

            if (room == null)
                return null;

            _ctx.Rooms.Remove(room);
            await _ctx.SaveChangesAsync();

            return room;
        }

        public async Task<List<Hotel>> GetAllHotelsAsync()
        {
            return await _ctx.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            var hotel = await _ctx.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                return null;

            return hotel;
        }

        public async Task<Room> GetHotelRoomByIdAsync(int hotelId, int roomId)
        {
            var room = await _ctx.Rooms.FirstOrDefaultAsync(r => r.HotelId == hotelId && r.RoomId == roomId);
            if (room == null)
                return null;

            return room;
        }

        public async Task<List<Room>> ListHotelRoomsAsync(int hotelId)
        {
            return await _ctx.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();
        }

        public async Task<Hotel> UpdateHotelAsync(Hotel updatedHotel)
        {
            _ctx.Hotels.Update(updatedHotel);
            await _ctx.SaveChangesAsync();
            return updatedHotel;
        }

        public async Task<Room> UpdateHotelRoomAsync(int hotelId, Room updatedRoom)
        {
            _ctx.Rooms.Update(updatedRoom);
            await _ctx.SaveChangesAsync();

            return updatedRoom;
        }
    }
}
