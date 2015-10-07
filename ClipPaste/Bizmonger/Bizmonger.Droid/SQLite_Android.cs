using Xamarin.Forms;
using Bizmonger.Droid;
using System.IO;
using SQLite;
using System.Linq;

[assembly: Dependency(typeof(Database_Android))]
namespace Bizmonger.Droid
{
    public class Database_Android : IDataConnection
    {
        public SQLiteConnection Connect()
        {
            var fileName = "Clipboard_SQLite.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }

        public bool TableExists(SQLiteConnection connection, string tableName) => connection.GetTableInfo(tableName).Any();
    }
}