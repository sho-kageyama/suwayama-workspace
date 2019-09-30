using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class OrderDetailRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public OrderDetailRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            //_db.DropTable<OrderInfo>();
            _db.CreateTable<OrderInfo>();
        }

        public IEnumerable<OrderInfo> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<OrderInfo>().Where(oi => oi.Delete == false && oi.Save == false);
            }
        }

        public IEnumerable<OrderInfo> GetSlipId(int Id)
        {
            lock (Locker)
            {
                string slipId = Id.ToString();
                return _db.Table<OrderInfo>().Where(oi => oi.SlipId == slipId && oi.Delete == false && oi.Save == false);
            }
        }

        public IEnumerable<OrderInfo> DeleteOrderHistory(int Id)
        {
            lock (Locker)
            {
                string slipId = Id.ToString();
                return _db.Table<OrderInfo>().Where(oi => oi.SlipId == slipId && oi.Delete == true);
            }
        }

        public IEnumerable<OrderInfo> SaveOrderHistory(int Id)
        {
            lock (Locker)
            {
                string slipId = Id.ToString();
                return _db.Table<OrderInfo>().Where(oi => oi.SlipId == slipId && oi.Save == true);
            }
        }

        public IEnumerable<OrderInfo> GetInstance(int Id)
        {
            lock (Locker)
            {
                string slipId = Id.ToString();
                return _db.Table<OrderInfo>().Where(oi => oi.SlipId == slipId);
            }
        }

        public int GetTotal(int Id)
        {
            lock (Locker)
            {
                string slipId = Id.ToString();
                var total = _db.Table<OrderInfo>().Where(oi => oi.SlipId == slipId);
                int Sum = 0;
                foreach (OrderInfo oi in total)
                {
                    Sum += oi.Sum;
                }
                return Sum;
            }
        }

        public int SaveOrderInfo(OrderInfo info)
        {
            lock (Locker)
            {
                if(info.Id != 0)
                {
                    _db.Update(info);
                    return info.Id;
                }
                _db.Insert(info);
                return info.Id;
            }
        }
    }
}
