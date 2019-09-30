using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class UserTypeRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public UserTypeRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            _db.CreateTable<UserType>();
        }


        public IEnumerable<UserType> GetUserTypes()
        {
            lock (Locker)
            {
                return _db.Table<UserType>().Where(ut => ut.Id != 0);
            }
        }


        public List<string> GetTypeList()
        {
            lock (Locker)
            {
                var type = GetUserTypes();
                List<string> typeList = new List<string>();
                foreach(UserType u in type)
                {
                    typeList.Add(u.Name);
                }
                return typeList;
            }
        }

        public int GetId(string name)
        {
            lock (Locker)
            {
                var list = _db.Table<UserType>().Where(ut => ut.Name == name);
                int Id = 0;
                foreach(UserType ut in list)
                {
                    Id = ut.Id;
                }
                return Id;
            }
        }



        public void Delete(UserType userType)
        {
            lock (Locker)
            {
                _db.Table<UserType>().Delete(ut => ut.Id == userType.Id);
            }
        }


        public int SaveUserType(UserType userType)
        {
            lock (Locker)
            {
                if(_db.Table<UserType>().Count(ut => ut.Name == userType.Name) == 0)
                {
                    if(userType.Id != 0)
                    {
                        _db.Update(userType);
                        return userType.Id;
                    }
                    return _db.Insert(userType);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
