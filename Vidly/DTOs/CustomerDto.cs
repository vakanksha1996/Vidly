using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedTonewsLetter { get; set; }
        public MemberShipTypeDto MemberShipType { get; set; }

        public int MemberShipTypeId { get; set; }
    }
}