using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class WorkRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public WorkRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<Work>();
            _db.CreateTable<Work>();
        }


        public IEnumerable<Work> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<Work>().Where(w => w.Id != 0);
            }
        }


        public Work FindOne(string name)
        {
            lock (Locker)
            {
                return _db.Table<Work>().Where(w => w.UserName == name && w.Day == DateTime.Now.ToLongDateString()).First();
            }
        }

        public IEnumerable<Work> FindDay(string Day)
        {
            lock (Locker)
            {
                return _db.Table<Work>().Where(w => w.Day == Day);
            }
        }

        public List<string> FindStuff(string Day)
        {
            lock (Locker)
            {
                var list = _db.Table<Work>().Where(w => w.Day == Day && w.State == true);
                List<string> stuffList = new List<string>();
                foreach(Work w in list)
                {
                    stuffList.Add(w.UserName);
                }
                stuffList.Add("お客様");
                return stuffList;
            }
        }


        public int SaveWork(Work work)
        {
            lock (Locker)
            {
                if(work.Id != 0)
                {
                    _db.Update(work);
                    return work.Id;
                }
                return _db.Insert(work);
            }
        }
    }
}
