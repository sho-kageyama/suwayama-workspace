using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Entyties
{
    public class UserDetail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int RewardType { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public bool Delete { get; set; }
    }
}
