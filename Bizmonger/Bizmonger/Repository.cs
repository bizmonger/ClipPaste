using SQLite;
using System;
using System.Linq;
using DataAccessMediator;
using Xamarin.Forms;
using Entities;
using Bizmonger.Patterns;

namespace Bizmonger
{
    public class Repository : IRepository
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        SQLiteConnection _databaseConnection = null;
        #endregion

        public Repository()
        {
            _messagebus.Subscribe(Messages.REQUEST_REPOSITORY, OnRequestRepository);
            _messagebus.Subscribe(Messages.REQUEST_SAVE_CONTENT, obj => Save(obj as Content));

            InitializeDatabase();
        }
        
        public Content Get(int id)
        {
            var content = _databaseConnection.Table<Content>().FirstOrDefault(x => x.Id == id);
            return content;
        }

        public void Save(Content content)
        {
            var existingContent = _databaseConnection.Table<Content>().FirstOrDefault(x => x.Id == content.Id);

            if (existingContent != null)
            {
                _databaseConnection.Update(content);
            }
            else
            {
                _databaseConnection.Insert(content);
            }
        }

        #region Helpers
        private void InitializeDatabase()
        {
            _databaseConnection = DependencyService.Get<IDatabase>().Connect();

            var tableExists = DependencyService.Get<IDatabase>().TableExists(_databaseConnection, "Content");

            if (!tableExists)
            {
                _databaseConnection.CreateTable<Content>();
            }
        }

        private void OnRequestRepository(object obj)
        {
            var dataAccessType = (DataAccessType)obj;

            if (dataAccessType == DataAccessType.Integration)
            {
                _messagebus.Publish(Messages.REPOSITORY_RESPONSE, this);
            }
        }
        #endregion
    }
}