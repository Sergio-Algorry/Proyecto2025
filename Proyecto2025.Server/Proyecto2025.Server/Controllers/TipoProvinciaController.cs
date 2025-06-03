using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/TipoProvincia")]
    public class TipoProvinciaController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoProvinciaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoProvincia>>> GetTipoProvincias()
        {
            var tipoProvincias = await context.TipoProvincias.ToListAsync();
            if (tipoProvincias == null)
            {
                return NotFound("No se encontraron tipos de provincia, VERIFICAR.");
            }
            if (tipoProvincias.Count == 0)
            {
                return Ok("No existe tipos de provincia en este momento.");
            }

            return Ok(tipoProvincias);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TipoProvincia DTO)
        {
            await context.TipoProvincias.AddAsync(DTO);
            await context.SaveChangesAsync();
            return Ok(DTO.Id);
        }
    }
}
