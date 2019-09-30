using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class Work
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Minus { get; set; }
        public int ExPenses { get; set; }
        public bool State { get; set; }

    }
}
