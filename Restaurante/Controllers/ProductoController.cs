using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> ReadAll()
        {
            return await _productoService.ReadAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> ReadById(int id)
        {
            Producto venta = await _productoService.ReadById(id);
            if (venta is null)
                return NotFound();
            return venta;
        }
        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto venta)
        {
            return await _productoService.Create(venta);
        }
        [HttpPut]
        public async Task<ActionResult<Producto>> Update(Producto venta)
        {
            return await _productoService.Update(venta);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            Producto venta = await _productoService.Delete(id);
            if (venta is null)
                return NotFound();
            return venta;
        }

    }

}