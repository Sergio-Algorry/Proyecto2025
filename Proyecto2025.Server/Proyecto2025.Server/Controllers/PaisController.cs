using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/Pais")]
    public class PaisController : ControllerBase
    {
        private readonly AppDbContext context;

        public PaisController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet] //api/Pais
        public async Task<ActionResult<List<Pais>>> GetFull()
        {
            var lista = await context.Paises.ToListAsync();
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpGet("{id:int}")]  //api/Pais/5
        public async Task<ActionResult<Pais>> GetById(int id)
        {
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(entidad);
        }

        [HttpGet("GetByAlpha3Code/{cod}")] // api/Pais/GetByAlpha3Code/ARG 
        public async Task<ActionResult<Pais>> GetByAlpha3Code(string cod)
        {
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.Alpha3Code == cod);
            if (entidad is null)
            {
                return NotFound($"No existe registro con el codigo: {cod}.");
            }

            return Ok(entidad);
        }

        [HttpGet("GetByCodIndec/{cod}")] // api/Pais/GetByCodIndec/ARG
        public async Task<ActionResult<Pais>> GetByCodIndec(string cod)
        {
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.CodIndec == cod);
            if (entidad is null)
            {
                return NotFound($"No existe registro con el codigo: {cod}.");
            }

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Pais DTO)
        {
            try
            {                
                await context.Paises.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el registro: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]  // api/Pais/6
        public async Task<ActionResult> Put(int id, Pais DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("Datos no validos.");
            }
            var existe = await context.Paises.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Update(DTO);
            await context.SaveChangesAsync();
            return Ok($"Registro con el id: {id} actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]  // api/Pais/6
        public async Task<ActionResult> Delete(int id)
        {
            //var existe = await context.Paises.AnyAsync(x => x.Id == id);
            //if (existe == false)
            //{
            //    return NotFound($"No existe el tipo de provincia con el id: {id}.");
            //}
            var tipoProvincia = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if(tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Paises.Remove(tipoProvincia);
            await context.SaveChangesAsync();
            return Ok($"Registro con el id: {id} eliminado correctamente.");
        }
    }
}
