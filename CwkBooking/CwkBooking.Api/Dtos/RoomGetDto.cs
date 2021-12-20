namespace CwkBooking.Api.Dtos
{
    public class RoomGetDto
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
    }
}
