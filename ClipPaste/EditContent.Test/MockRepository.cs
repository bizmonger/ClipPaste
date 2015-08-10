using System;
using Mediation;
using Entities;
using Bizmonger.Patterns;

namespace EditContent.Test
{
    public class MockRepository : IRepository
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        Content _content = null;
        #endregion

        public MockRepository()
        {
            _messagebus.Subscribe("REQUEST_REPOSITORY", OnRequestRepository);
            _messagebus.Subscribe("REQUEST_SAVE_CONTENT", obj => Save(obj as Content));
        }

        
        public Content Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Content content)
        {
            _content = content;
        }

        #region Helpers
        private void OnRequestRepository(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}