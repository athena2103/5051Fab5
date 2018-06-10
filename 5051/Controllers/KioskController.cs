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
        public ActionResult Index(int DisplayMsgType = 0)
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            StudentViewModel.DisplayMsgType = DisplayMsgType;
            return View(StudentViewModel);
        }



        /// <summary>
        /// Landing page for admin to unlock the Kiosk
        /// </summary>
        /// <returns></returns>
        // GET: Kiosk/Landing
        public ActionResult Landing()
        {           
            return View(StudentViewModel);
        }

        /// <summary>
        /// Landing page for admin to unlock the Kiosk
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        // POST: Kiosk/Landing
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
        // GET: Kiosk/NewProfile
        public ActionResult NewProfile()
        {
            var myData = new StudentModel();
            return View(myData);
        }

        /// <summary>
        /// Make a new Student sent in by the create Student screen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Kiosk/NewProfile
        [HttpPost]
        public ActionResult NewProfile([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "AvatarId,"+
                                        "Status,"+
                                        "")] StudentModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Return back for Edit
                return View(data);
            }

            //Assign blank reports to a new student
            var Reports = StudentReportBackend.Instance.Index();
            var Report = Reports[Reports.Count - 1].Uri;
            data.ReportsId = Report;
            data.Status = StudentStatusEnum.In;

            StudentBackend.Create(data);
           
            return RedirectToAction("Index", new { DisplayMsgType = 1 });
            
        }

        // GET: Kiosk/SetLogin/5
        public ActionResult SetLogin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error","Home","Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            StudentBackend.UpTokens(id, 100);
            return RedirectToAction("Index", new { DisplayMsgType = 2});
        }

        // GET: Kiosk/SetLogout/5
        public ActionResult SetLogout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            StudentBackend.UpTokens(id, 100);
            return RedirectToAction("Index", new { DisplayMsgType = 3});
        }
    }
}
