using Microsoft.AspNetCore.Mvc;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/TipoProvincia")]
    public class TipoProvinciaController : ControllerBase
    {
        public TipoProvinciaController()
        {
        }

        [HttpGet]
        public IActionResult GetTipoProvincias()
        {
            // Aquí deberías implementar la lógica para obtener las provincias desde tu base de datos o servicio.
            // Por ahora, retornamos un ejemplo estático.
            var provincias = new List<string> { "pepe", "juan", "Provincia3", "otro reghistro" };
            return Ok(provincias);
        }
    }
}
