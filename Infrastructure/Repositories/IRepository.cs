using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Save();
        void Delete(int id);
    }
}
