using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;

namespace TaskLoger.Core.DAL
{
    public class TaskDataContext : DbContext
    {
        static TaskDataContext()
        {
            Database.SetInitializer<TaskDataContext>(new DbInitializer());
        }
        public TaskDataContext()
            : base("DbConnection")
        { }
        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<TaskModel> Tasks { get; set; }

        public DbSet<TaskListModel> TaskLists { get; set; }
    }
}