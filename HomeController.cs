﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contactus()
        {

            return View();
        }

        public ActionResult Aboutus()
        {

            return View();
        }
        //SQLInjectionMessage

        public ActionResult SQLInjectionMessage()
        {

            return View();
        }
    }
}
