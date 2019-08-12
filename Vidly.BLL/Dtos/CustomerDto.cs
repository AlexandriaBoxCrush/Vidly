using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using System.Text;
using Vidly.DAL.Objects;


namespace Vidly.BLL.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customers Name")]
        [StringLength(255)]
        [SourceMember("CustomerName")]
        public string Name { get; set; }

        [SourceMember("SubscribedToNewsLetter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [SourceMember("MembershipTypeId")]
        public byte MembershipTypeId { get; set; }

        [SourceMember("Birthdate")]
        public DateTime? Birthdate { get; set; }
    }
}
