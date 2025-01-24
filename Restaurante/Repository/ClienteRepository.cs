using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly Db _context;

        public ClienteRepository(Db context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> ReadAll()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<(List<Cliente> Items, int TotalCount)> ReadPaged(int page, int pageSize)
        { 
            var totalCount = await _context.Clientes.CountAsync();
            var items = await _context.Clientes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Cliente> Delete(int id)
        {
            Cliente cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null)
                return null;
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
        }
        public async Task<Cliente> ReadById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
