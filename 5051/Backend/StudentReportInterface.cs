using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{

    /// <summary>
    /// Datasource Interface for Student Reports
    /// </summary>
    public interface IStudentReportInterface
    {
        StudentReportModel Create(StudentReportModel data);
        StudentReportModel Read(string id);
        List<StudentReportModel> Index();
        void Reset();
    }
}