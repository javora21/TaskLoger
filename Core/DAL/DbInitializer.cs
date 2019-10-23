using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;

namespace TaskLoger.Core.DAL
{
    class DbInitializer : CreateDatabaseIfNotExists<TaskDataContext>
    {
        protected override void Seed(TaskDataContext db)
        {
            ProjectModel p1 = new ProjectModel() { Name = "First", CreateDate = DateTime.Now };
            ProjectModel p2 = new ProjectModel() { Name = "Second", CreateDate = DateTime.Now };
            ProjectModel p3 = new ProjectModel() { Name = "Third", CreateDate = DateTime.Now };


            db.Projects.Add(p1);
            db.Projects.Add(p2);
            db.Projects.Add(p3);

            db.SaveChanges();
        }
    }
}