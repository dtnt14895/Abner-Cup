using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Cliente>>> ReadAll()
        {
            return await _clienteService.ReadAll();
        }
        [HttpGet("{id}")]
        [Authorize(Policy = "admin")]
        public async Task<ActionResult<Cliente>> ReadById(int id)
        {
            Cliente cliente = await _clienteService.ReadById(id);
            if (cliente is null)
                return NotFound();
            return cliente;
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            cliente.Nombre = cliente.Nombre;
            cliente.Apellido = cliente.Apellido;
            cliente.Telefono = cliente.Telefono;
            cliente.Direccion = cliente.Direccion;
            cliente.Correo = cliente.Correo;

            return await _clienteService.Create(cliente);
        }
        [HttpPut]
        public async Task<ActionResult<Cliente>> Update(Cliente cliente)
        {
            return await _clienteService.Update(cliente);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            Cliente cliente = await _clienteService.Delete(id);
            if (cliente is null)
                return NotFound();
            return cliente;
        }

    }

}