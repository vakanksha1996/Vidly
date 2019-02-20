using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
       [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedTonewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name="MemberShipType")]
        public int MemberShipTypeId { get; set; }
    }
}