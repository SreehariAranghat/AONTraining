using Library.Entities;

namespace Library.Data
{
    public interface IRepository<T> where T : BaseObject
    {
        T FindById(int id);
        List<T> GetAll();

        T Add(T entity);
        T Update(T entity);
        void Delete(int id);

    }
}
