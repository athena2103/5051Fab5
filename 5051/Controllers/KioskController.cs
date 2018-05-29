using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    /// <summary>
    /// The Kiosk that will run in the classroom
    /// </summary>
    public class KioskController : Controller
    {
        // A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        /// <summary>
        /// Return the list of students with the status of logged in or out
        /// </summary>
        /// <returns></returns>
        // GET: Kiosk
        public ActionResult Index()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }

        /// <summary>
        /// Landing page for admin to unlock the Kiosk
        /// </summary>
        /// <returns></returns>
        // GET: Kiosk
        public ActionResult Landing()
        {           
            return View(StudentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Landing(string passphase = "")
        {
            string valid = "schoolworks";
            if (passphase == "")
            {
                // Send to Error Page
                ModelState.AddModelError("Error", "Admin passphase does not match.");
                return View();
            }
            if(passphase == valid) {
                return RedirectToAction("Index");
            } else {

                ModelState.AddModelError("Error", "Admin passphase does not match.");
                return View();

            }
        }

        /// <summary>
        /// For students to create a new profile at the Kiosk
        /// </summary>
        /// <returns></returns>
        // GET: Kiosk
        public ActionResult NewProfile()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }

        // GET: Kiosk/SetLogin/5
        public ActionResult SetLogin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error","Home","Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            string name = StudentBackend.Read(id).Name;
            TempData["ReturnMsg"] = "Clock in successfully at " + DateTime.Now + "!";
            StudentBackend.UpTokens(id, 100);
            TempData["balance"] = StudentBackend.Read(id).Tokens;
            return RedirectToAction("Index");
        }

        // GET: Kiosk/SetLogout/5
        public ActionResult SetLogout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            TempData["ReturnMsg"] = "Clock out successfully at " + DateTime.Now + "!";
            StudentBackend.UpTokens(id, 100);
            TempData["balance"] = StudentBackend.Read(id).Tokens;
            StudentBackend.ToggleStatusById(id);
            
            return RedirectToAction("Index");
        }
    }
}
