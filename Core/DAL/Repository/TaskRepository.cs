using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;
using TaskLoger.Core.DAL.IRepository;
using TaskLoger.Models.ViewModels;

namespace TaskLoger.Core.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        TaskDataContext _dataContext;
        public TaskRepository(TaskDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void DeleteTask(int taskId)
        {
            
            var task = _dataContext.Tasks.Where(x => x.Id == taskId).FirstOrDefault();
            var taskList = _dataContext.TaskLists.Where(x => x.TaskId == taskId).FirstOrDefault();

            _dataContext.TaskLists.Remove(taskList);
            _dataContext.Tasks.Remove(task);

            _dataContext.SaveChanges();
        }

        public void EditTask(TaskModel taskModel, TaskListModel listModel)
        {
            var taskDB = _dataContext.Tasks.Find(taskModel.Id);
            var listDB = _dataContext.TaskLists.Where(x => x.TaskId == taskModel.Id).FirstOrDefault();


            taskDB.Ticket = taskModel.Ticket;
            taskDB.ProjectId = taskModel.ProjectId;
            taskDB.Description = taskModel.Description;

            listDB.StartDate = listModel.StartDate;
            listDB.CancelDate = listModel.CancelDate;

            _dataContext.SaveChanges();
        }

        public IEnumerable<TableModel> GetTasks()
        {

            return JoinTaskTable();
        }

        public IEnumerable<TableModel> GetTasks(DateTime date)
        {
            return JoinTaskTable().Where(x => DbFunctions.TruncateTime(x.CreateDate) == date.Date);

        }

        public IEnumerable<TableModel> GetTasks(int projectId)
        {
            return JoinTaskTable().Where(x => x.ProjectId == projectId);

        }

        public IEnumerable<TableModel> GetTasks(DateTime date, int projectId)
        {
            return JoinTaskTable().Where(x => DbFunctions.TruncateTime(x.CreateDate) == date.Date && x.ProjectId == projectId);
        }

        public void SaveNewTask(TaskModel taskModel,TaskListModel listModel)
        {
            _dataContext.Tasks.Add(taskModel);
            _dataContext.TaskLists.Add(listModel);

            _dataContext.SaveChanges();
        }

        private IQueryable<TableModel> JoinTaskTable()
        {
            return _dataContext.TaskLists.Join(_dataContext.Tasks, l => l.TaskId, t => t.Id, (l, t) =>
            new TableModel
            {
                Id = t.Id,
                Ticket = t.Ticket,
                Description = t.Description,
                Start = l.StartDate,
                End = l.CancelDate,
                CreateDate = l.CreateDate,
                ProjectId = t.ProjectId

            });
        }
    }
}