using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class CarDescription
    {
        public Guid CarDescriptionId { get; set; }
        
        public string Details { get; set; }

        public Car Car { get; set; }
        public Guid CarId { get; set; }



    }
}
