using SQLite;
using SQLiteDemo.Entyties;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class MenuRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public MenuRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<Entyties.Menu>();
            _db.CreateTable<Entyties.Menu>();

        }


        public IEnumerable<Entyties.Menu> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<Entyties.Menu>().ToList();
            }
        }


        public IEnumerable<Entyties.Menu> GetMenus()
        {
            lock (Locker)
            {
                return _db.Table<Entyties.Menu>().Where(m => m.Id != 0);
            }
        }

        public int FindPrice(string name)
        {
            lock (Locker)
            {
                var menu = _db.Table<Entyties.Menu>().Where(m => m.Name == name).First();
                return menu.Price;
            }
        }

        public Entyties.Menu FindOne(string id)
        {
            lock (Locker)
            {
                int Id = int.Parse(id);
                return _db.Table<Entyties.Menu>().Where(m => m.Id == Id).First();
            }
        }




        public string GetSetId(string price)
        {
            lock (Locker)
            {
                int p = int.Parse(price);
                var menu = _db.Table<Entyties.Menu>().Where(m => m.Price == p && m.TypeId == 7).First();
                string Id = menu.Id.ToString();
                
                return Id;
            }

        }

        public string GetMenuName(string id)
        {
            lock (Locker)
            {
                int Id = int.Parse(id);
                var menu = _db.Table<Entyties.Menu>().Where(m => m.Id == Id).First();
                return  menu.Name;
                
            }
        }

        public List<int> GetSetList()
        {
            lock (Locker)
            {
                var set = _db.Table<Entyties.Menu>().Where(m => m.TypeId == 7);
                List<int> setList = new List<int>();
                foreach(Entyties.Menu m in set)
                {
                    setList.Add(m.Price);
                }
                return setList;
            }
        }

        public void DeleteMenu(Entyties.Menu menu)
        {
            lock (Locker)
            {
                _db.Table<Entyties.Menu>().Delete(m => m.Id == menu.Id);
            }
        }

        public int SaveMenu(Entyties.Menu menu)
        {
            lock (Locker)
            {
                if(_db.Table<Entyties.Menu>().Count(m => m.Name == menu.Name) == 0)
                {
                    if (menu.Id != 0)
                    {
                        _db.Update(menu);
                        return menu.Id;
                    }
                    return _db.Insert(menu);
                }
                return 0;
            }
        }
    }
}
