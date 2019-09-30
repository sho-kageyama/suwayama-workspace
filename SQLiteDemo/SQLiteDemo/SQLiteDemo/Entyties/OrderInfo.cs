using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
   public class OrderInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SlipId { get; set; }
        public string GuestId { get; set; }
        public string MenuId { get; set; }
        public string TargetId { get; set; }
        public int Count { get; set; }
        public int Back { get; set; }

        public int Sum { get; set; }
        public bool Save { get; set; }

        public bool Delete { get; set; }
    }
}
