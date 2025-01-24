using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _ventaService;
        public VentaController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> ReadAll()
        {
            return await _ventaService.ReadAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> ReadById(int id)
        {
            Venta venta = await _ventaService.ReadById(id);
            if (venta is null)
                return NotFound();
            return venta;
        }
        [HttpPost]
        public async Task<ActionResult<Venta>> Create(Venta venta)
        {
            return await _ventaService.Create(venta);
        }
        [HttpPut]
        public async Task<ActionResult<Venta>> Update(Venta venta)
        {
            return await _ventaService.Update(venta);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venta>> Delete(int id)
        {
            Venta venta = await _ventaService.Delete(id);
            if (venta is null)
                return NotFound();
            return venta;
        }

    }

}