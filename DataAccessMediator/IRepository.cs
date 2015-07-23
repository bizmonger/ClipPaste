using Entities;

namespace DataAccessMediator
{
    public interface IRepository
    {
        void Save(Content content);
        Content Get(int id);
    }
}