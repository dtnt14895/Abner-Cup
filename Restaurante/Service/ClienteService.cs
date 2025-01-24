using FluentValidation;
using Restaurante.Models;
using Restaurante.Repository;
using Restaurante.Validators;

namespace Restaurante.Service
{
    public class ClienteService : IService<Cliente>
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly IValidator<Cliente> _clienteValidator;
        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _clienteValidator= new Validator();
        }
        public async Task<Cliente> Create(Cliente entity)
        {
            await _clienteValidator.ValidateAndThrowAsync(entity);
            try
            { 
                return await _clienteRepository.Create(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Error ...", e);
            }
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
