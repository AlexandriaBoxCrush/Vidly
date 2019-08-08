using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Vidly.DAL.Objects;

namespace Vidly.DAL.Objects
{
    public class Customer
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customers Name")] //No longer nullable
        [StringLength(255)] //Attribute length
        public string Name { get; set; }


        //MIGRATION AddIsSubcribedToCustomer
        public bool IsSubscribedToNewsletter { get; set; }

        //MIGRATION MembershipType
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
        public DateTime? Birthdate { get; set; }
    }
}
