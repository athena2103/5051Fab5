using System.Web.Mvc;
using System.Collections.Generic;
using _5051.Models;
using _5051.Backend;

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
                return View(StudentViewModel);
            }
            

        }

        // GET: Report
        /// <summary>
        /// Returns an individual report for a student
        /// </summary>
        /// <param name="id">Student ID to generate Report for</param>
        /// <returns>Report data</returns>
        /**
        public ActionResult Report(string id)
        {
            var singleData = StudentBackend.Read(id);
            List <StudentModel> singleList = new List<StudentModel>();
            singleList.Add(singleData);
            var StudentViewModel = new StudentViewModel(singleList);
            return View(StudentViewModel);
        }*/

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
    }
}