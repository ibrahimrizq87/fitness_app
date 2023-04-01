using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class Steps
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string day { get; set; }
        public int steps { get; set; }
    }
}
