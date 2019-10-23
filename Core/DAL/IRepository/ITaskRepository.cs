using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskLoger.Core.DAL.DbModels;
using TaskLoger.Models.ViewModels;

namespace TaskLoger.Core.DAL.IRepository
{
    public interface ITaskRepository
    {
        //TODO: Change objects to type from new DbModel folders
        void SaveNewTask(TaskModel taskModel, TaskListModel listModel);

        void EditTask(TaskModel taskModel, TaskListModel listModel);

        void DeleteTask(int taskId);

        IEnumerable<TableModel> GetTasks();

        IEnumerable<TableModel> GetTasks(DateTime date);

        IEnumerable<TableModel> GetTasks(int projectId);

        IEnumerable<TableModel> GetTasks(DateTime date, int projectId);
    }
}