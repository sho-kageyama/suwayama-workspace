using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class UserRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public UserRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<User>();
            _db.CreateTable<User>();
        }

        public IEnumerable<User> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<User>().Where(u => u.Id != 0);
            }
        }

        public IEnumerable<User> KyastStuffAll()
        {
            lock (Locker)
            {
                return _db.Table<User>().Where(u => u.TypeId > 2);
            }
        }

        public List<string> GetUsers()
        {
            lock (Locker)
            {
                var user = _db.Table<User>().Where(u => u.TypeId > 2 && u.State == true);
                List<string> userList = new List<string>();
                foreach(User u in user)
                {
                    userList.Add(u.Name);
                }
                userList.Add("お客様");
                return userList;
            }
        }

        public User FindOne(string name)
        {
            lock (Locker)
            {
                return _db.Table<User>().Where(u => u.Name == name).First();
            }
        }


        public int GetUserId(string name)
        {
            lock (Locker)
            {
                var user = _db.Table<User>().Where(u => u.Name == name);
                int Id = 0;
                foreach(User u in user)
                {
                    Id = u.Id;
                }
                return Id;
            }
        }


        public void Delete(User user)
        {
            lock (Locker)
            {
                _db.Table<User>().Delete(u => u.Id == user.Id);
            }
        }

        public int SaveUser(User user)
        {
            lock (Locker)
            {
                if (user.Id != 0)
                {
                    _db.Update(user);
                    return user.Id;
                }
                else if (_db.Table<User>().Count(u => u.Name == user.Name) == 0)
                {
                    return 0;
                }
                _db.Insert(user);
                return user.Id;
            }

        }
    }
}
