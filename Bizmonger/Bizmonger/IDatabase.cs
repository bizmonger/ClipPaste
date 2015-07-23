using SQLite;

namespace Bizmonger
{
    public interface IDatabase
    {
        SQLiteConnection Connect();

        bool TableExists(SQLiteConnection connection, string tableName);
    }
}