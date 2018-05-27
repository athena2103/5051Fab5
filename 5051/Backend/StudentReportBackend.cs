using _5051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Backend
{
    /// <summary>
    // Student Report Backend handles the business logic and data for individual report
    /// </summary>
    public class StudentReportBackend
    {
        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile StudentReportBackend instance;
        private static object syncRoot = new Object();

        private StudentReportBackend() { }

        public static StudentReportBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StudentReportBackend();
                            SetDataSource(SystemGlobals.Instance.DataSourceValue);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
        private static IStudentReportInterface DataSource;

        /// <summary>
        /// Sets the Datasource to be Mock or SQL
        /// </summary>
        /// <param name="dataSourceEnum"></param>
        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            if (dataSourceEnum == DataSourceEnum.SQL)
            {
                // SQL not hooked up yet...
                throw new NotImplementedException();
            }

            // Default is to use the Mock
            DataSource =  StudentReportSourceMock.Instance;
        }
        
        /// <summary>
        /// Embed a new report
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public StudentReportModel Create(StudentReportModel data)
        {
            DataSource.Create(data);
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

            var myReturn = DataSource.Read(id);
            return myReturn;
        }


        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of student reports</returns>
        public List<StudentReportModel> Index()
        {
            var myData = DataSource.Index();
            return myData;
        }

        

        /// <summary>
        /// Helper function that returns the Report Image URI
        /// </summary>
        /// <param name="data">The studentreportId to look up</param>
        /// <returns>null, or the report image URI</returns>
        public List<string> GetReportUri(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            List<string> myReturn = null;

            var myData = DataSource.Read(data);
            if (myData != null)
            {
                myReturn = myData.Uri;
            }

            return myReturn;
        }


        /// <summary>
        /// Helper function that resets the DataSource, and rereads it.
        /// </summary>
        public void Reset()
        {
            DataSource.Reset();
        }
    }
}