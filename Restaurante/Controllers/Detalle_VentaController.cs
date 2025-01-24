using Microsoft.AspNetCore.Mvc;
using Restaurante.Models;
using Restaurante.Service;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detalle_VentaController : ControllerBase
    {
        private readonly Detalle_VentaService _detalle_VentaService;
        public Detalle_VentaController(Detalle_VentaService detalle_VentaService)
        {
            _detalle_VentaService = detalle_VentaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle_Venta>>> ReadAll()
        {
            return await _detalle_VentaService.ReadAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle_Venta>> ReadById(int id)
        {
            Detalle_Venta detalle_Venta = await _detalle_VentaService.ReadById(id);
            if (detalle_Venta is null)
                return NotFound();
            return detalle_Venta;
        }
        [HttpPost]
        public async Task<ActionResult<Detalle_Venta>> Create(Detalle_Venta detalle_Venta)
        {
            return await _detalle_VentaService.Create(detalle_Venta);
        }
        [HttpPut]
        public async Task<ActionResult<Detalle_Venta>> Update(Detalle_Venta detalle_Venta)
        {
            return await _detalle_VentaService.Update(detalle_Venta);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detalle_Venta>> Delete(int id)
        {
            Detalle_Venta detalle_Venta = await _detalle_VentaService.Delete(id);
            if (detalle_Venta is null)
                return NotFound();
            return detalle_Venta;
        }

    }

}