using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class TableSlipRelay
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string TableId { get; set; }
        
        public int SlipId { get; set; }
        public DateTime InsertDay { get; set; }
        public bool Delete { get; set; }
        public bool Save { get; set; }
    }
}
