using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLoger.Models.ViewModels;

namespace TaskLoger.Core.Buisness.IService
{
    public interface ITaskService
    {
         string GetSumTime { get; set; }

        void SaveNewTask(FormModel model);

        void EditTask(FormModel model);

        void DeleteTask(FormModel model);

        IEnumerable<TableModel> GetTasks(FilterModel model);

        
    }
}
