using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class SetRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public SetRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            _db.CreateTable<Set>();
        }

        public IEnumerable<Set> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<Set>().Where(s => s.Id != 0);
            }
        }

        public List<Set> SetList()
        {
            lock (Locker)
            {
                var set =_db.Table<Set>();
                List<Set> setList = new List<Set>();
                foreach(Set s in set)
                {
                    setList.Add(s);
                }
                return setList;
            }
        }

        public string GetName(string price)
        {
            lock (Locker)
            {
                int Price = int.Parse(price);
                var set =  _db.Table<Set>().Where(s => s.Price == Price).First();
                return set.Name;
            }

        }

        public Set FindOne(string id)
        {
            lock (Locker)
            {
                return _db.Table<Set>().Where(s => s.Name == id).First();
            }
        }

        public int Delete(Set set)
        {
            lock (Locker)
            {
                return _db.Table<Set>().Delete(s => s.Id == set.Id);
            }
        }

        public int SaveSet(Set set)
        {
            lock (Locker)
            {
                if(set.Id != 0)
                {
                    _db.Update(set);
                    return set.Id;
                }
                _db.Insert(set);
                return set.Id;
            }
        }
    }
}
