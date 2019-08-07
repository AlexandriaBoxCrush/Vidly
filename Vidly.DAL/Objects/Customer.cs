using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DAL.Objects
{
    public class Customer
    {

        public int Id { get; set; }
        [Required] //No longer nullable
        [StringLength(255)] //Attribute length
        public string Name { get; set; }


        //MIGRATION AddIsSubcribedToCustomer
        public bool IsSubscribedToNewsletter { get; set; }

        //MIGRATION MembershipType
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
