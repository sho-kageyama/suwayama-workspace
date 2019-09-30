using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class UserType
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
