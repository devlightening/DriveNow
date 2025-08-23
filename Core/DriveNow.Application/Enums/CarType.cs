using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Enums
{
    public enum CarType
    {
        // Default value, represents an unknown state.
        None = 0,

        // The most common car type.
        Sedan = 1,

        // A small, fuel-efficient car type.
        Hatchback = 2,

        // A taller, more spacious vehicle.
        Suv = 3,

        // A car with a larger cargo area.
        StationWagon = 4,

        // A larger vehicle for multiple passengers.
        Minivan = 5,

        // An environmentally friendly vehicle type.
        Electric = 6,

        // A sporty, two-door car.
        Coupe = 7,

        // A truck with an open bed.
        Pickup = 8
    }
}
