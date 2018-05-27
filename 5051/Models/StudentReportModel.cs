using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _5051.Models
{
    /// <summary>
    /// Reports for each student
    /// </summary>
    public class StudentReportModel
    {
        [Display(Name = "Id", Description = "Report Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Display(Name = "Uri", Description = "Report image to Show")]
        [Required(ErrorMessage = "Report image is required")]
        public List<string> Uri { get; set; }

        [Display(Name = "Name", Description = "Avatar Name")]
        [Required(ErrorMessage = "Report Name is required")]
        public string Name { get; set; }


        /// <summary>
        /// Create the default values
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// New Avatar
        /// </summary>
        public StudentReportModel()
        {
            Initialize();
        }

        /// <summary>
        /// Make an Avatar from values passed in
        /// </summary>
        /// <param name="uri">List of the Picture path</param>
        /// <param name="name">Report Name</param>
        public StudentReportModel(List<string> uri, string name)
        {
            Initialize();

            Uri = uri;
            Name = name;
        }

        
    }
}