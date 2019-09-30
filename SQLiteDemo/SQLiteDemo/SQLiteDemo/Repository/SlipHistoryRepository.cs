using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class SlipHistoryRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public SlipHistoryRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<SaveSlip>();
            _db.CreateTable<SaveSlip>();
        }

        public IEnumerable<SaveSlip> GetSaveHistory()
        {
            lock (Locker)
            {
                return _db.Table<SaveSlip>().Where(ss => ss.Save == true);
            }
        }

        public IEnumerable<SaveSlip> GetDeleteHistory()
        {
            lock (Locker)
            {
                return _db.Table<SaveSlip>().Where(ss => ss.Delete == true);
            }
        }


        public int SaveSSlip(SaveSlip slip)
        {
            lock (Locker)
            {
                if(slip.Id != 0)
                {
                    _db.Update(slip);
                    return slip.Id;
                }
                return _db.Insert(slip);
            }
        }


    }
}
