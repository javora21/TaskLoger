using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskLoger.Core.DAL.DbModels
{
    [Table("TaskList")]
    public class TaskListModel
    {
        [Key]
        public int Id { get; set; }

        public TaskModel Task { get; set; }

        public int TaskId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CancelDate { get; set; }

        public DateTime CreateDate { get; set; }
    }
}