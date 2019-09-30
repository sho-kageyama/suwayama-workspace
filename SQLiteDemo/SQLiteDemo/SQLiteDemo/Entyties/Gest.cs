using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class Gest
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TableId { get; set; }
        public int SlipId { get; set; }

        public DateTime InsertDate { get; set; }

        public bool Delete { get; set; }
    }
}
