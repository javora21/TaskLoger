using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskLoger.Models.ViewModels
{
    public class TableModel
    {
        public int Id { get; set; }

        public string Ticket { get; set; }

        public int ProjectId { get; set; }

        public TimeSpan Time { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string TimeFormat { get; set; }

        public string StartFormat { get; set; }

        public string EndFormat { get; set; }

        public DateTime CreateDate { get; set; }
    }
}