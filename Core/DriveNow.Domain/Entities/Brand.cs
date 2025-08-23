using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }



    }
}
