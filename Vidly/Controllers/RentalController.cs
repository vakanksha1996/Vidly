﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }
    }
}