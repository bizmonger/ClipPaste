using SQLite;

namespace Entities
{
    public class Content
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}