using System.ComponentModel.DataAnnotations;

namespace CwkBooking.Api.Dtos
{
    public class HotelCreateDto
    {
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        
        [Required]
        [Range(1,5)]
        public int Stars { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
