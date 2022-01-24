using AutoMapper;
using CwkBooking.Api.Dtos;
using CwkBooking.Domain.Models;

namespace CwkBooking.Api.Automapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<ReservationPutPostDto, Reservation>();
            CreateMap<Reservation, ReservationGetDto>();
        }
    }
}
