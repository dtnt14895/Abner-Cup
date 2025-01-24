using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Repository
{
    public class ProductoRepository : IRepository<Producto>
    {
        private readonly Db _context;

        public ProductoRepository(Db context)
        {
            _context = context;
        }
        public async Task<List<Producto>> ReadAll()
        {
            return await _context.Productos.ToListAsync();
        }
        public async Task<Producto> Create(Producto entity)
        {
            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Producto> Delete(int id)
        {
            Producto cliente = await _context.Productos.FindAsync(id);
            if (cliente is null)
                return null;
            {
                _context.Productos.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
        public async Task<Producto> ReadById(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
