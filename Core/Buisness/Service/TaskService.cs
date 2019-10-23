using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskLoger.Core.Buisness.IService;
using TaskLoger.Core.DAL.DbModels;
using TaskLoger.Core.DAL.IRepository;
using TaskLoger.Models.ViewModels;

namespace TaskLoger.Core.Buisness.Service
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public string GetSumTime { get; set; }

        public void DeleteTask(FormModel model)
        {
            _taskRepository.DeleteTask(int.Parse(model.TaskId));
        }

        public void EditTask(FormModel model)
        {
            var task = new TaskModel
            {
                Ticket = model.TaskName,
                Description = model.Description,
                ProjectId = int.Parse(model.ProjectId),
                Id = int.Parse(model.TaskId)
            };
            var list = new TaskListModel
            {
                Task = task,
                StartDate = DateTime.Parse(model.StartTime),
                CancelDate = DateTime.Parse(model.EndTime),
                CreateDate = DateTime.Now
            };
            _taskRepository.EditTask(task, list);
        }

        public IEnumerable<TableModel> GetTasks(FilterModel model)
        {
            List<TableModel> tableModel;
            if (string.IsNullOrEmpty(model.FilterProject) && string.IsNullOrEmpty(model.FilterDate))
                tableModel = _taskRepository.GetTasks().ToList();
            else if (string.IsNullOrEmpty(model.FilterDate))
                tableModel = _taskRepository.GetTasks(int.Parse(model.FilterProject)).ToList();
            else if (string.IsNullOrEmpty(model.FilterProject))
                tableModel = _taskRepository.GetTasks(DateTime.Parse(model.FilterDate)).ToList();
            else
                tableModel = _taskRepository.GetTasks(DateTime.Parse(model.FilterDate), int.Parse(model.FilterProject)).ToList();

            TimeSpan sum = new TimeSpan(0, 0, 0);
            foreach (var i in tableModel)
            {
                i.Time = i.End.Subtract(i.Start);
                sum += i.Time;
                i.TimeFormat = i.Time.ToString("hh':'mm");
                i.EndFormat = i.End.ToString("HH':'mm");
                i.StartFormat = i.Start.ToString("HH':'mm");
            }
            GetSumTime = sum.ToString("hh':'mm");


            return tableModel;
        }

        public void SaveNewTask(FormModel model)
        {
            var task = new TaskModel {
                Ticket = model.TaskName,
                Description = model.Description,
                ProjectId = int.Parse(model.ProjectId)
            };
            var list = new TaskListModel
            {
                Task = task,
                StartDate = DateTime.Parse(model.StartTime),
                CancelDate = DateTime.Parse(model.EndTime),
                CreateDate = DateTime.Now
            };
            _taskRepository.SaveNewTask(task, list);
        }
    }
}