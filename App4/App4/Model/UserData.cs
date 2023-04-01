using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public float hight { get; set; }
        public int age { get; set; }
        public float weight { get; set; }
    }
}
