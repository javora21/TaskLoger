using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskLoger.Core.DAL.DbModels
{
    [Table("Task")]
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ticket { get; set; }

        public string Description { get; set; }

        public ProjectModel Project { get; set; }

        public int ProjectId { get; set; }

    }
}