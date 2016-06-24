﻿using MyLinkedIn.Data;
using System.Web.Mvc;

namespace MyLinkedIn.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMyLinkedInDataUoW data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (UserProfile != null)
            {
                ViewBag.Username = UserProfile.UserName;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}