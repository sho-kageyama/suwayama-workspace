using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class SaveSlip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SlipId { get; set; }
        public DateTime EndTime { get; set; }
        public bool Save { get; set; }
        public bool Delete { get; set; }
    }
}
