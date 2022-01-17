using System;

namespace CwkBooking.Domain.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }      
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public string Customer { get; set; }
    }
}
