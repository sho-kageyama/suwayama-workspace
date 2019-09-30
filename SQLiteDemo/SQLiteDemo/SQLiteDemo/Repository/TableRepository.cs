using System.Collections.Generic;
using SQLite;
using SQLiteDemo.Entyties;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class TableRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public TableRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<Tabel>();
            _db.CreateTable<Tabel>();
        }

        public IEnumerable<Tabel> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<Tabel>().Where(t => t.Delete == false);
            }
        }


        public Tabel FindOne(string name)
        {
            lock (Locker)
            {
                return _db.Table<Tabel>().Where(t => t.Name == name).First();
            }
        }

        public IEnumerable<Tabel> GetTabels()
        {
            lock (Locker)
            {
                return _db.Table<Tabel>().Where(t => t.Delete == false && t.Use == false);
            }
        }


        public bool UsedJudge(string name)
        {
            lock (Locker)
            {
                var judge =_db.Table<Tabel>().Count(t => t.Name == name && t.Use == false);
                if(judge == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetId(string name)
        {
            lock (Locker)
            {
                var table = _db.Table<Tabel>().Where(t => t.Name == name);
                int Id = 0;
                foreach(Tabel t in table)
                {
                    Id = t.Id;
                }
                return Id;
            }
        }

        public int SaveTable(Tabel table)
        {
            lock (Locker)
            {
                if(table.Id != 0)
                {
                    _db.Update(table);
                    return table.Id;
                }
                return _db.Insert(table);
            }
        }
    }
}
