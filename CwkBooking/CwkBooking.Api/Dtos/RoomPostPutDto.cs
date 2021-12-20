namespace CwkBooking.Api.Dtos
{
    public class RoomPostPutDto
    {
        public int RoomNumber { get; set; }
        public double Surface { get; set; }
        public bool NeedsRepair { get; set; }
    }
}
