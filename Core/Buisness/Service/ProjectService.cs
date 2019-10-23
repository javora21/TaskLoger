using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskLoger.Core.Buisness.IService;
using TaskLoger.Core.DAL.IRepository;

namespace TaskLoger.Core.Buisness.Service
{
    public class ProjectService:IProjectService
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<object> GetProjects()
        {
           return  _projectRepository.GetProjects();
        }
    }
}