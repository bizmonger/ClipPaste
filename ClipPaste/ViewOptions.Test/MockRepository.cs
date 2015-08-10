using Mediation;
using Entities;
using System;

namespace ViewMenu.Test
{
    public class MockRepository : IRepository
    {
        public Content Get(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        return new Content() { Id = 1, Value = "Some text 1" };
                    }

                case 2:
                    {
                        return new Content() { Id = 2, Value = "Some text 2" };
                    }

                case 3:
                    {
                        return new Content() { Id = 3, Value = "Some text 3" };
                    }

                case 4:
                    {
                        return new Content() { Id = 4, Value = "Some text 4" };
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public void Save(Content content)
        {
            throw new NotImplementedException();
        }
    }
}