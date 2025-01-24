namespace Restaurante.Service
{
    public interface IService<T>
    {
        Task<List<T>> ReadAll();
        Task<T> ReadById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
