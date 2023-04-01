using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class Calories
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string day { get; set; }
        public float calories { get; set; }

    }
}
