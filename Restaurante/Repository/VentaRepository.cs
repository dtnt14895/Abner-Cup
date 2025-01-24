using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Repository
{
    public class VentaRepository : IRepository<Venta>
    {
        private readonly Db _context;

        public VentaRepository(Db context)
        {
            _context = context;
        }
        public async Task<List<Venta>> ReadAll()
        {
            return await _context.Ventas.ToListAsync();
        }
        public async Task<Venta> Create(Venta entity)
        {
            _context.Ventas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Venta> Delete(int id)
        {
            Venta cliente = await _context.Ventas.FindAsync(id);
            if (cliente is null)
                return null;
            {
                _context.Ventas.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
        public async Task<Venta> ReadById(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task<Venta> Update(Venta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
