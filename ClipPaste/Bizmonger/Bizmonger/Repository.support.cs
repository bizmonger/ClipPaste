﻿using Bizmonger.Patterns;
using Mediation;
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
            _databaseConnection = DependencyService.Get<IDataConnection>().Connect();

            var tableExists = DependencyService.Get<IDataConnection>().TableExists(_databaseConnection, "Content");

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