using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLoger.Core.Buisness.IService
{
    public interface IProjectService
    {
        IEnumerable<object> GetProjects();
    }
}
