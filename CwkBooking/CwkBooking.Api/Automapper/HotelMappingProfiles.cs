using AutoMapper;
using CwkBooking.Api.Dtos;
using CwkBooking.Domain.Models;

namespace CwkBooking.Api.Automapper
{
    public class HotelMappingProfiles : Profile
    {
        public HotelMappingProfiles()
        {
            CreateMap<HotelCreateDto, Hotel>();
            CreateMap<Hotel, HotelGetDto>();
        }
    }
}
