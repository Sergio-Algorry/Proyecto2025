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

        [HttpGet] //api/TipoProvincia
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

        [HttpGet("{id:int}")]  //api/TipoProvincia/5
        public async Task<ActionResult<TipoProvincia>> GetById(int id)
        {
            var tipoProvincia = await context.TipoProvincias.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el tipo de provincia con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("{cod}")]  //api/TipoProvincia/PRU
        public async Task<ActionResult<TipoProvincia>> GetByCod(string cod)
        {
            var tipoProvincia = await context.TipoProvincias.FirstOrDefaultAsync(x => x.Codigo == cod);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el tipo de provincia con el codigo: {cod}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TipoProvincia DTO)
        {
            try
            {                
                await context.TipoProvincias.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el tipo de provincia: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Put(int id, TipoProvincia DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("Datos no validos.");
            }
            var existe = await context.TipoProvincias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"No existe el tipo de provincia con el id: {id}.");
            }
            context.Update(DTO);
            await context.SaveChangesAsync();
            return Ok($"Tipo de provincia con el id: {id} actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Delete(int id)
        {
            //var existe = await context.TipoProvincias.AnyAsync(x => x.Id == id);
            //if (existe == false)
            //{
            //    return NotFound($"No existe el tipo de provincia con el id: {id}.");
            //}
            var tipoProvincia = await context.TipoProvincias.FirstOrDefaultAsync(x => x.Id == id);
            if(tipoProvincia is null)
            {
                return NotFound($"No existe el tipo de provincia con el id: {id}.");
            }
            context.TipoProvincias.Remove(tipoProvincia);
            await context.SaveChangesAsync();
            return Ok($"Tipo de provincia con el id: {id} eliminado correctamente.");
        }
    }
}
