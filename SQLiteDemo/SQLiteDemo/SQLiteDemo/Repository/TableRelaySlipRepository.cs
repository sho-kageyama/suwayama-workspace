using SQLite;
using SQLiteDemo.Entyties;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQLiteDemo.Repository
{
    public class TableRelaySlipRepository
    {
        static readonly object Locker = new object();
        readonly SQLiteConnection _db;

        public TableRelaySlipRepository()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection();
            _db.CreateTable<TableSlipRelay>();
        }

        public IEnumerable<TableSlipRelay> FindAll()
        {
            lock (Locker)
            {
                return _db.Table<TableSlipRelay>().Where(tsr => tsr.Delete == false);
            }
        }

        public int GetSlipId(string table)
        {
            lock (Locker)
            {
                var slip = _db.Table<TableSlipRelay>().Where(tsr => tsr.TableId == table && tsr.Save == false);
                int Id = 0;
                foreach(TableSlipRelay tsr in slip)
                {
                    Id = tsr.SlipId;
                }
                return Id;
            }
        }

        public int SaveRelay(TableSlipRelay tableSlip)
        {
            lock (Locker)
            {
                if(tableSlip.Id != 0)
                {
                    _db.Update(tableSlip);
                    return tableSlip.Id;
                }
                return _db.Insert(tableSlip);
            }
        }



    }
}
