using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class SlipRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public SlipRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<Slipcs>();
            _db.CreateTable<Slipcs>();
        }


        


        public IEnumerable<Slipcs> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<Slipcs>().Where(s => s.Delete == false && s.Save == false);
            }
        }

        public Slipcs FindOne(int Id)
        {
            lock (Locker)
            {
                return _db.Table<Slipcs>().Where(s => s.Id == Id).First();
            }
        }


        public int GetSlipId(string Name)
        {
            lock (Locker)
            {
                var slip = _db.Table<Slipcs>().Where(s => s.TableName == Name && s.Save == false);
                int Id = 0;
                foreach(Slipcs s in slip)
                {
                    Id = s.Id;
                }
                return Id;
            }
        }


        public int SaveSlipcs(Slipcs slip)
        {
            lock (Locker)
            {
                if (slip.Id != 0)
                {
                    _db.Update(slip);
                    return slip.Id;
                }
                return _db.Insert(slip);
            }

        }
    }
}
