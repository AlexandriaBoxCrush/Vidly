using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.DAL.Objects;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        [Min18YearsIfAMember]
        public Customer Customer { get; set; }
    }
}
