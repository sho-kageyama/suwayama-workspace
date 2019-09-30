using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class MenuTypeRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public MenuTypeRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<MenuType>();
            _db.CreateTable<MenuType>();
        }

        public IEnumerable<MenuType> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<MenuType>().Where(mt => mt.Id != 0);
            }
        }

        public List<string> GetStringList()
        {
            lock (Locker)
            {
                var list = _db.Table<MenuType>().Where(mt => mt.Id != 0);
                List<string> mtList = new List<string>();
                foreach(MenuType m in list)
                {
                    mtList.Add(m.Name);
                }
                return mtList;
            }
        }

        public int GetId(string name)
        {
            lock (Locker)
            {
                var Type = _db.Table<MenuType>().Where(mt => mt.Name == name);
                int Id = 0;
                   foreach(MenuType m in Type)
                {
                    Id = m.Id;
                }

                return Id;
                 
               
            }
        }



        public void DeleteType(MenuType type)
        {
            lock (Locker)
            {
                _db.Table<MenuType>().Delete(mt => mt.Id == type.Id);
            }
        }

       
        public int SaveType(MenuType menuType)
        {
            lock (Locker)
            {
                if(menuType.Id != 0)
                {
                    _db.Update(menuType);
                    return menuType.Id;
                }
                return _db.Insert(menuType);
            }
        }

    }
}
