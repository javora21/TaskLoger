using Ninject.Modules;
using Ninject.Web.Common;
using TaskLoger.Core.Buisness.IService;
using TaskLoger.Core.Buisness.Service;
using TaskLoger.Core.DAL;
using TaskLoger.Core.DAL.IRepository;
using TaskLoger.Core.DAL.Repository;

namespace TaskLoger.Util
{
    public class NinjectDependency:NinjectModule
    {
        public override void Load()
        {
            Bind<TaskDataContext>().To<TaskDataContext>().InRequestScope();

            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<ITaskRepository>().To<TaskRepository>();

            Bind<IProjectService>().To<ProjectService>();
            Bind<ITaskService>().To<TaskService>();
        }
    }
}