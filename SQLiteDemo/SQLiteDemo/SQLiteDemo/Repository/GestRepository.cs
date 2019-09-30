using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class GestRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public GestRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<Gest>();
            _db.CreateTable<Gest>();
        }


        public void ResetTable()
        {
            _db.DropTable<Gest>();
            _db.CreateTable<Gest>();
        }

        public IEnumerable<Gest> getGests(string tableId)
        {
            lock (Locker)
            {
                return _db.Table<Gest>().Where(g => g.TableId == tableId && g.Delete == false);
            }
        }


        public int CountGuest(int slipId)
        {
            lock (Locker)
            {
                return _db.Table<Gest>().Where(g => g.SlipId == slipId && g.Delete == true).Count();
            }
        }


        public List<string> GuestList(string name)
        {
            lock (Locker)
            {
                var guests = _db.Table<Gest>().Where(g => g.TableId == name && g.Delete == false);
                List<string> gestList = new List<string>();
                foreach(Gest g in guests)
                {
                    gestList.Add(g.Name);
                }
                return gestList;
            }
        }


        public int SaveGest(Gest gest)
        {
            lock (Locker)
            {
                if(gest.Id != 0)
                {
                    _db.Update(gest);
                    return gest.Id;
                }
                return _db.Insert(gest);
            }
        }
    }
}
