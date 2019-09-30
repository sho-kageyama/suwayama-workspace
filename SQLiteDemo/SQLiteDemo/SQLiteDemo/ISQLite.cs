using SQLite;

namespace SQLiteDemo
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
