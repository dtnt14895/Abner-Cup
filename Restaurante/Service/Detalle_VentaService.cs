using Restaurante.Models;
using Restaurante.Repository;

namespace Restaurante.Service
{
    public class Detalle_VentaService : IService<Detalle_Venta>
    {
        private readonly Detalle_VentaRepository _detalle_VentaRepository;
        public Detalle_VentaService(Detalle_VentaRepository detalle_VentaRepository)
        {
            _detalle_VentaRepository = detalle_VentaRepository;
        }
        public async Task<Detalle_Venta> Create(Detalle_Venta entity)
        {
            return await _detalle_VentaRepository.Create(entity);
        }

        public async Task<Detalle_Venta> Delete(int id)
        {
            return await _detalle_VentaRepository.Delete(id);
        }

        public async Task<List<Detalle_Venta>> ReadAll()
        {
            return await _detalle_VentaRepository.ReadAll();
        }

        public async Task<Detalle_Venta> ReadById(int id)
        {
            return await _detalle_VentaRepository.ReadById(id);
        }

        public async Task<Detalle_Venta> Update(Detalle_Venta entity)
        {
            return await _detalle_VentaRepository.Update(entity);
        }
    }
}
