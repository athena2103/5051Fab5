using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    /// View Model for the Student Index, this will have the list of the students in it convered to a StudentDisplayViewModel
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// The student List to return to the View
        /// </summary>
        public List<StudentDisplayViewModel> StudentList = new List<StudentDisplayViewModel>();

        /// <summary>
        /// Single student to return to the View
        /// </summary>
        public StudentDisplayViewModel Student { get; set; }

        public int DisplayMsgType { get; set;}

        public string ReturnMsg { get; set; }
    
        public string DisplayMsg()
        {
            if (DisplayMsgType == 1)
            {
                return "Account created successfully at " + DateTime.Now + "!";
            }
            else if (DisplayMsgType == 2)
            {
                return "Clocked in successfully at " + DateTime.Now + "!\n Your point balance has been increased by 100.";
            }
            else if (DisplayMsgType == 3)
            {
                return "Clocked out successfully at " + DateTime.Now + "!\n Your point balance has been increased by 100.";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Default constructor, needed becase of the constructor that takes a List of Student Models
        /// </summary>
        public StudentViewModel() { }

        /// <summary>
        /// Take the data list passed in, and convert each to a new StudentDisplayViewModel item and add that to the StudentList
        /// </summary>
        /// <param name="dataList"></param>
        public StudentViewModel(List<StudentModel> dataList)
        {
            foreach (var item in dataList)
            {
                StudentList.Add(new StudentDisplayViewModel(item));
            }
            ReturnMsg = DisplayMsg();
            DisplayMsgType = 0;
        }

        /// <summary>
        /// Take the data passed in, and convert to a new StudentDisplayViewModel item
        /// </summary>
        /// <param name="data"></param>
        public StudentViewModel(StudentModel data)
        {
            Student = new StudentDisplayViewModel(data);
        }
    }
}