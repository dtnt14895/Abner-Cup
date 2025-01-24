using Restaurante.Models;
using Restaurante.Repository;

namespace Restaurante.Service
{
    public class ProductoService : IService<Producto>
    {
        private readonly ProductoRepository _productoRepository;
        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<Producto> Create(Producto entity)
        {
            return await _productoRepository.Create(entity);
        }

        public async Task<Producto> Delete(int id)
        {
            return await _productoRepository.Delete(id);
        }

        public async Task<List<Producto>> ReadAll()
        {
            return await _productoRepository.ReadAll();
        }

        public async Task<Producto> ReadById(int id)
        {
            return await _productoRepository.ReadById(id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            return await _productoRepository.Update(entity);
        }
    }
}
