using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Paises.Estados.Data;
using Mundo.Api.Paises.Estados.Domain;

namespace Mundo.Api.Paises.Estados.Controllers
{
    [Route("api/Pais")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly MundoApiPaisesEstadosContext _context;

        public PaisController(MundoApiPaisesEstadosContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
            return await _context.Pais.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(Guid id)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Pais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(Guid id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pais
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
           _context.Pais.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPais", new { id = pais.Id }, pais);
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> DeletePais(Guid id)
        {
            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();

            return pais;
        }

        private bool PaisExists(Guid id)
        {
            return _context.Pais.Any(e => e.Id == id);
        }

        [HttpGet("{id}/Estados")]
        public async Task<ActionResult> GetEstados([FromRoute] Guid id)
        {
            var pais = await _context.Pais.Include(x => x.Estados).FirstOrDefaultAsync(x => x.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            var response = pais.Estados;

            return Ok(response);
        }

        [HttpPost("{id}/Estados")]
        public async Task<ActionResult> PostEstados([FromRoute] Guid id, [FromBody] Guid idEstado)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados.FindAsync(idEstado);

            pais.Estados.Add(estado);

            _context.Pais.Update(pais);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}/Estados")]
        public async Task<ActionResult> DeleteEstados([FromRoute] Guid id, [FromBody] Guid idEstado)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            var estado = await _context.Estados.FindAsync(idEstado);

            pais.Estados.Remove(estado);

            _context.Pais.Update(pais);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
