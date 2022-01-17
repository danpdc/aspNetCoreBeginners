using CwkBooking.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CwkBooking.Domain.Abstractions.Services
{
    public interface IReservationService
    {
        Task<Reservation> MakeReservation(Reservation reservation);
    }
}
