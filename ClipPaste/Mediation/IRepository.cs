using Entities;

namespace Mediation
{
    public interface IRepository
    {
        void Save(Content content);
        Content Get(int id);
    }
}