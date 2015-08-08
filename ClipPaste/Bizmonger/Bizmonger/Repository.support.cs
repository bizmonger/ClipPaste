using Bizmonger.Patterns;
using DataAccessMediator;
using Entities;
using SQLite;
using Xamarin.Forms;

namespace Bizmonger
{
    public partial class Repository
    {
        MessageBus _messagebus = MessageBus.Instance;
        SQLiteConnection _databaseConnection = null;

        void InitializeDatabase()
        {
            _databaseConnection = DependencyService.Get<IDatabase>().Connect();

            var tableExists = DependencyService.Get<IDatabase>().TableExists(_databaseConnection, "Content");

            if (!tableExists)
            {
                _databaseConnection.CreateTable<Content>();
            }
        }

        void OnRequestRepository(object obj)
        {
            var dataAccessType = (DataAccessType)obj;

            if (dataAccessType == DataAccessType.Integration)
            {
                _messagebus.Publish(Messages.REPOSITORY_RESPONSE, this);
            }
        }
    }
}