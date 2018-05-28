using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    /// <summary>
    /// Home Controller is the default controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The Home page for the site
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The Error page for the site
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// The about page for Avatar Attendance
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// The contact us page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// The Privacy Policy page
        /// </summary>
        /// <returns></returns>
        public ActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Help/Example page for AdminIntro View
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminIntro ()
        {
            return View();
        }

        /// <summary>
        /// Help/Example page for Kiosk Intro View
        /// </summary>
        /// <returns></returns>
        public ActionResult KioskIntro()
        {
            return View();
        }

        /// <summary>
        /// Help/Example page for Student Intro View
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentIntro()
        {
            return View();
        }

        /// <summary>
        /// Help/Example page for Avatar Levels
        /// </summary>
        /// <returns></returns>
        public ActionResult AvatarExample()
        {
            return View();
        }
    }
}