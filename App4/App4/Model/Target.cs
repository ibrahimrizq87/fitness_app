using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class Target
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string day { get; set; }
        public bool isDone { get; set; }
        public string heartRate { get; set; }
        public int steps { get; set; }
        public int calories { get; set; }

    }
}
