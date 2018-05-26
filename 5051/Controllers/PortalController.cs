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
        /// The Login in page for the Portal, shows all the Students
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
        /// Display logout page
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            return View();
        }

        /// <summary>
        /// Student default page after login
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult FirstIndex()
        {
            return View();
        }
        
        /// <summary>
        /// Index Page
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
