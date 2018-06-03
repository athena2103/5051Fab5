using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    /// <summary>
    /// Backend Mock DataSource for Reports, to manage them
    /// </summary>
    public class StudentReportSourceMock : IStudentReportInterface
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile StudentReportSourceMock instance;
        private static object syncRoot = new Object();

        private StudentReportSourceMock() { }

        public static StudentReportSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StudentReportSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The Report List
        /// </summary>
        private List<StudentReportModel> reportList = new List<StudentReportModel>();

        /// <summary>
        /// Embed a new report image
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public StudentReportModel Create(StudentReportModel data)
        {
            reportList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public StudentReportModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = reportList.Find(n => n.Id == id);
            return myReturn;
        }


        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of reports</returns>
        public List<StudentReportModel> Index()
        {
            return reportList;
        }

        /// <summary>
        /// Reset the Data, and reload it
        /// </summary>
        public void Reset()
        {
            reportList.Clear();
            Initialize();
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            var count = 0;
            var countX = 0;
            
           
            for (count = 1; count < 7; count++)
            {
                
                List<string> reports = new List<string>();
                if (count == 6)
                {
                    reports = Enumerable.Repeat("blankReport.PNG", 4).ToList();
                }
                else
                {
                    for (countX = 1; countX < 5; countX++)
                    {
                        reports.Add("student" + count.ToString() + "_" + countX.ToString()
                        + "Attendance.PNG");
                    }
                }
                
                Create(new StudentReportModel(reports, "Report"
                    + count.ToString()));
            }

            

        }
    }
}