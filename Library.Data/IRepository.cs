using Library.Entities;

namespace Library.Data
{
    public interface IRepository<T> where T : BaseObject
    {
        Task<T> FindById(int id);
        Task<List<T>> GetAll();

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);

    }
}
