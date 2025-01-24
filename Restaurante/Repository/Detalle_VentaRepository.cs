using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Repository
{
    public class Detalle_VentaRepository : IRepository<Detalle_Venta>
    {
        private readonly Db _context;

        public Detalle_VentaRepository(Db context)
        {
            _context = context;
        }
        public async Task<List<Detalle_Venta>> ReadAll()
        {
            return await _context.Detalle_Ventas.ToListAsync();
        }
        public async Task<Detalle_Venta> Create(Detalle_Venta entity)
        {
            _context.Detalle_Ventas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Detalle_Venta> Delete(int id)
        {
            Detalle_Venta cliente = await _context.Detalle_Ventas.FindAsync(id);
            if (cliente is null)
                return null;
            {
                _context.Detalle_Ventas.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
        public async Task<Detalle_Venta> ReadById(int id)
        {
            return await _context.Detalle_Ventas.FindAsync(id);
        }

        public async Task<Detalle_Venta> Update(Detalle_Venta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
