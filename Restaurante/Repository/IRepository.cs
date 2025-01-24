﻿namespace Restaurante.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> ReadAll();
        Task<T> ReadById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
