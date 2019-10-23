using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskLoger.Models;
using Newtonsoft.Json;
using TaskLoger.Models.ViewModels;
using TaskLoger.Util;
using TaskLoger.Core.Buisness.IService;

namespace TaskLoger.Controllers
{
    public class TaskController : Controller
    {
        private IProjectService _projectService;
        private ITaskService _taskService;

        public TaskController(IProjectService projectService, ITaskService taskService)
        {
           _projectService = projectService;
           _taskService = taskService;
        }

        public ActionResult Index()
        {
            
            return View(_projectService.GetProjects());
        }

        public ActionResult LoadTable(FilterModel filter)
        {
            List<TableModel> model = _taskService.GetTasks(filter).ToList();
            object mod = new {data = model, sumTime = _taskService.GetSumTime };
            return Json(mod,JsonRequestBehavior.AllowGet);
        }
        public void AddNewTask(FormModel model)
         {
           _taskService.SaveNewTask(model);
        }

        public void EditTask(FormModel model)
        {
           _taskService.EditTask(model);
        }

        public void DeleteTask(FormModel model)
        {
           _taskService.DeleteTask(model);
        }
    }


    
}