using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miniproject.Models
{
    public class Tasks
    {
        [PrimaryKey, AutoIncrement]
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
    }
}
