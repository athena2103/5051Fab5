using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    public class PortalController : Controller
    {
        /// <summary>
        /// The Login in page for the student portal, ask user for email and password
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// The Login in page for the Admin Portal
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult AdminLogin()
        {
            return View();
        }

        /// <summary>
        /// Display logout page for the student portal
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            return View();
        }

        /// <summary>
        /// Index Page for student portal
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  My Settings
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Settings()
        {
            return View();
        }
    }
}
