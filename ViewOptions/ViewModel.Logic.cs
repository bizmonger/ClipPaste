using DataAccessMediator;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace ViewMenu
{
    public partial class ViewModel
    {
        private void OnLoadContent(object obj)
        {
            var repository = obj as IRepository;

            var dbContent1 = repository.Get(1);
            var dbContent2 = repository.Get(2);
            var dbContent3 = repository.Get(3);
            var dbContent4 = repository.Get(4);

            Content1 = dbContent1 != null ? dbContent1 : new Content() { Id = 1, Value = "CopyMade & paste me *1*" };
            Content2 = dbContent2 != null ? dbContent2 : new Content() { Id = 2, Value = "CopyMade & paste me *2*" };
            Content3 = dbContent3 != null ? dbContent3 : new Content() { Id = 3, Value = "CopyMade & paste me *3*" };
            Content4 = dbContent4 != null ? dbContent4 : new Content() { Id = 4, Value = "CopyMade & paste me *4*" };
        }

        public void OnContentSelected(object obj)
        {
            var content = GetContent(obj);
            SelectedContent = content;
        }
        
        private void OnContentRequested(object obj)
        {
            var text = obj as string;
            var content = GetContent(obj);
            _messagebus.Publish(Messages.REQUEST_CONTENT_RESPONSE, content);
        }

        private Content GetContent(object obj)
        {
            var text = obj as string;
            var contentList = new List<Content>() { Content1, Content2, Content3, Content4 };
            var content = contentList.Where(c => c.Value == text).FirstOrDefault();
            return content;
        }
    }
}
