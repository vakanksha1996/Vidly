﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerViewModel
    {
      public   List<MemberShipType> MemberShipTypes { get; set; }
       public  Customer customer { get; set; }
     
    }
}