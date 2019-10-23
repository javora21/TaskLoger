using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskLoger.Core.DAL.DbModels
{
    [Table("Project")]
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public List<TaskModel> Tasks { get; set; }
    }
}