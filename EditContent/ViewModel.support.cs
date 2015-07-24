namespace EditContent
{
    public partial class Commands
    {
        private void OnSave(object obj)
        {
            _messagebus.Publish(Messages.REQUEST_SAVE_CONTENT, obj);
            _messagebus.Publish(Messages.REQUEST_REFRESH_CONTENT, obj);
            _messagebus.Publish(Messages.REQUEST_PREVIOUS_VIEW, obj);
        }
    }
}