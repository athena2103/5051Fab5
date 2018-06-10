using System.Web.Mvc;
using System.Collections.Generic;
using _5051.Models;
using _5051.Backend;
using Rotativa;

namespace _5051.Controllers
{
    /// <summary>
    /// Controller for the Admin section of the website
    /// </summary>
    public class AdminController : Controller
    {
        // A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Reports
        /// </summary>
        /// <returns>All the Students that can have a report</returns>
        // GET: Report
        public ActionResult Manage(string id = null, string cmd = null)
        {

            // Load the list of data into the StudentList. If has ID, return one student's info
            //Otherwise, return all
           if(string.IsNullOrEmpty(id))
            {
                var myDataList = StudentBackend.Index();
                var StudentViewModel = new StudentViewModel(myDataList);
                return View(StudentViewModel);
            }
            else
            {
                var singleData = StudentBackend.Read(id);
                var StudentViewModel = new StudentViewModel(singleData);
                //Respond to update student's info request
                if(cmd == "Update")
                {
                    StudentViewModel.Student.IsUpdate = true;
                }
                return View(StudentViewModel);
            }
            

        }

        /// <summary>
        /// This updates the Student based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Student/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                      "Student")]StudentViewModel StudentView)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(StudentView);
            }

            if (StudentView == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if(StudentView.Student == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            
            if (string.IsNullOrEmpty(StudentView.Student.Id))
            {
                // Send back for edit
                return View(StudentView);
                
            }

            StudentView.Student.IsUpdate = false;
            StudentBackend.Update(StudentView.Student);

            return RedirectToAction("Manage", new { id = StudentView.Student.Id });
        }

        /// <summary>
        /// Print reports
        /// </summary>
        /// <returns></returns>
        // GET: Report
        public ActionResult PrintReport(string id = null, string isEmpty = null)
        {
            // Load the list of data into the StudentList. If has ID, return one student's info
            //Otherwise, return all
            if (string.IsNullOrEmpty(id))
            {
                var myDataList = StudentBackend.Index();
                var StudentViewModel = new StudentViewModel(myDataList);
                var a = isEmpty;
                TempData["ck"] = isEmpty;
                return new Rotativa.ViewAsPdf (StudentViewModel);
            }
            else
            {
                var singleData = StudentBackend.Read(id);
                var StudentViewModel = new StudentViewModel(singleData);
                return new Rotativa.ViewAsPdf(StudentViewModel);
            }
            
        }


        /// <summary>
        /// Calendar
        /// </summary>
        /// <returns></returns>
        // GET: Calendar
        public ActionResult Calendar()
        {
            return View();
        }

        /// <summary>
        /// Attendance Editing
        /// </summary>
        /// <returns></returns>
        // GET: Attendance
        public ActionResult Attendance()
        {
            return View();
        }

        /// <summary>
        /// Calls the data sources and has them reset to default data
        /// </summary>
        /// <returns></returns>
        // GET: Reset
        public ActionResult Reset()
        {
            AvatarDataSourceMock.Instance.Reset();
            StudentDataSourceMock.Instance.Reset();
            return RedirectToAction("Index", "Home");
        }

    }
}