using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkBooking.Domain.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
        public DateTime? BusyFrom { get; set; }
        public DateTime? BusyTo { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
