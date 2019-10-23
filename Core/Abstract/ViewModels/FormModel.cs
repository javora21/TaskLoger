using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;

namespace TaskLoger.Models.ViewModels
{
    public class FormModel
    {
        public string TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public string ProjectId { get; set; }

        public string Description { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public List<ProjectModel> Projects { get; set; }
    }
}