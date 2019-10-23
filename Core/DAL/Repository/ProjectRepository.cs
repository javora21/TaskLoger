using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;
using TaskLoger.Core.DAL.IRepository;

namespace TaskLoger.Core.DAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        TaskDataContext _dataContext;
        public ProjectRepository(TaskDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<ProjectModel> GetProjects()
        {
            return _dataContext.Projects;
        }
    }
}