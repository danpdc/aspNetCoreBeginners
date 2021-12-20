using System;

namespace CwkBooking.Domain.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Room Room { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Customer { get; set; }
    }
}
