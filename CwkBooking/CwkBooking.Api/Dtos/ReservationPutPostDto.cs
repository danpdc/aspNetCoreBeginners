using System;

namespace CwkBooking.Api.Dtos
{
    public class ReservationPutPostDto
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public string Customer { get; set; }
    }
}
