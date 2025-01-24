
using Repository;
using Restaurante.Models;

namespace Service
{
    public class ClienteService : IService<Cliente>
    {
        private readonly ClienteRepository _clienteRepository;
        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<Cliente> Create(Cliente entity)
        {
            return await _clienteRepository.Create(entity);
        }

        public async Task<Cliente> Delete(int id)
        {
            return await _clienteRepository.Delete(id);
        }

        public async Task<List<Cliente>> ReadAll()
        {
            return await _clienteRepository.ReadAll();
        }

        public async Task<Cliente> ReadById(int id)
        {
            return await _clienteRepository.ReadById(id);
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            return await _clienteRepository.Update(entity);
        }

    }
}
