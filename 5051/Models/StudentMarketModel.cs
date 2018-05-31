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
    /// Avatars for the system
    /// </summary>
    public class StudentMarketModel
    {
        [Display(Name = "Id", Description = "Item Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Display(Name = "Uri", Description = "Picture to Show")]
        [Required(ErrorMessage = "Picture is required")]
        public string Uri { get; set; }

        [Display(Name = "Name", Description = "Item Name")]
        [Required(ErrorMessage = "Avatar Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description", Description = "Item Description")]
        [Required(ErrorMessage = "Avatar Description is required")]
        public string Description { get; set; }

        [Display(Name = "Point", Description = "Item Point")]
        [Required(ErrorMessage = "Avatar Level is required")]
        public int Point { get; set; }

        /// <summary>
        /// Create the default values
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
            Point = 50;
        }

        /// <summary>
        /// New Avatar
        /// </summary>
        public StudentMarketModel()
        {
            Initialize();
        }

        /// <summary>
        /// Make an Avatar from values passed in
        /// </summary>
        /// <param name="uri">The Picture path</param>
        /// <param name="name">Avatar Name</param>
        /// <param name="description">Avatar Description</param>
        public StudentMarketModel(string uri, string name, string description, int point)
        {
            Initialize();

            Uri = uri;
            Name = name;
            Description = description;
            Point = point;
        }

        /// <summary>
        /// Used to Update Avatar Before doing a data save
        /// Updates everything except for the ID
        /// </summary>
        /// <param name="data">Data to update</param>
        public void Update(StudentMarketModel data)
        {
            if (data == null)
            {
                return;
            }

            Uri = data.Uri;
            Name = data.Name;
            Description = data.Description;
            Point = data.Point;
        }
    }
}