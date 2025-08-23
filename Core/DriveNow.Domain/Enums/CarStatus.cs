using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Enums
{
    public enum CarStatus
    {
        Available = 1,
        Rented = 2,
        InMaintenance = 3,
        Damaged = 4,
        Deactivated = 5,
    }
}
