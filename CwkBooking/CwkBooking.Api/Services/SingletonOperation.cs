using CwkBooking.Api.Services.Abstractions;
using System;

namespace CwkBooking.Api.Services
{
    public class SingletonOperation : ISingletonOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
