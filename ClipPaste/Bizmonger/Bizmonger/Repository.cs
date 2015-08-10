using System.Linq;
using Mediation;
using Entities;

namespace Bizmonger
{
    public partial class Repository : IRepository
    {
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
    }
}