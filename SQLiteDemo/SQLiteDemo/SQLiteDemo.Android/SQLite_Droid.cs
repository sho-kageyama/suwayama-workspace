using System;
using System.IO;
using SQLite;
using SQLiteDemo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace SQLiteDemo.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, "TodoSQLite.db3");

            return new SQLiteConnection(path);
        }
    }
}