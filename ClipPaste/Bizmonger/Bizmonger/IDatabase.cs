using SQLite;

namespace Bizmonger
{
    public interface IDataConnection
    {
        SQLiteConnection Connect();

        bool TableExists(SQLiteConnection connection, string tableName);
    }
}