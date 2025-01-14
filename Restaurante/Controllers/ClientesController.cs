using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(Db context) : ControllerBase
    {
        private readonly Db _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetClientes()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientesById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddClientes(Cliente newCliente)
        {
            if (newCliente is null)
                return BadRequest();

            if (_context.Clientes.Any(c => c.Id == newCliente.Id))
                return Conflict("A client with this ID already exists.");

            _context.Clientes.Add(newCliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClientesById), new { id = newCliente.Id }, newCliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCliente(int id, Cliente updateCliente)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null)
                return NotFound();

            cliente.Nombre = updateCliente.Nombre;
            cliente.Apellido = updateCliente.Apellido;
            cliente.Correo = updateCliente.Correo;
            cliente.Telefono = updateCliente.Telefono;
            cliente.Direccion = updateCliente.Direccion;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null)
                return NotFound();
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
