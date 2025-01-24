using Restaurante.Models;
using Restaurante.Repository;

namespace Restaurante.Service
{
    public class VentaService : IService<Venta>
    {
        private readonly VentaRepository _ventaRepository;
        public VentaService(VentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }
        public async Task<Venta> Create(Venta entity)
        {
            return await _ventaRepository.Create(entity);
        }

        public async Task<Venta> Delete(int id)
        {
            return await _ventaRepository.Delete(id);
        }

        public async Task<List<Venta>> ReadAll()
        {
            return await _ventaRepository.ReadAll();
        }

        public async Task<Venta> ReadById(int id)
        {
            return await _ventaRepository.ReadById(id);
        }

        public async Task<Venta> Update(Venta entity)
        {
            return await _ventaRepository.Update(entity);
        }
    }
}
