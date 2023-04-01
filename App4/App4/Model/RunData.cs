using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class RunData
    {
        [PrimaryKey]
        public string day { get; set; }
        public string calories { get; set; }
        public float steps { get; set; }
        public float distance { get; set; }
        public float maxSpeed { get; set; }
    }
}
