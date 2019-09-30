using SQLite;
using System;


namespace SQLiteDemo.Entyties
{
    public class Tabel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDay { get; set; }
        public bool Delete { get; set; }
        public bool Use { get; set; }
    

    }
}
