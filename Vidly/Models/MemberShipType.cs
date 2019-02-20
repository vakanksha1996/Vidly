using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public int DiscountRate { get; set; }
    }
}