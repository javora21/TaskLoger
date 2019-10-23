using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLoger.Core.DAL.DbModels;

namespace TaskLoger.Core.DAL.IRepository
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectModel> GetProjects();
    }
}
