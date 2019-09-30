using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class Set
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
    }
}
