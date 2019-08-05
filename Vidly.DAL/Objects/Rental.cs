using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.DAL.Objects
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
