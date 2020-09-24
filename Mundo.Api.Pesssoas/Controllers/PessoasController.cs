using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mundo.Api.Pessoas.Domain;
using Mundo.Api.Pessoas.Data;
using AutoMapper;

namespace Mundo.Api.Pessoas.Controllers
{
    [Route("api/Amigos")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly MundoApiPessoasContext _context;
        private readonly IMapper _mapper;

        public PessoasController(MundoApiPessoasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Pessoas>>> GetPessoas()
        {
            var pessoas = await _context.Pessoas.ToListAsync();

            var response = _mapper.Map<List<PessoasResponse>>(pessoas);

            return Ok(response);
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Pessoas>> GetPessoas(Guid id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        // PUT: api/Pessoas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoas(Guid id, Domain.Pessoas pessoas)
        {
            if (id != pessoas.Id)
            {
                return BadRequest();
            }

            _context.Entry(pessoas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoasExists(id))
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

        // POST: api/Pessoas
        [HttpPost]
        public async Task<ActionResult<Domain.Pessoas>> PostPessoas(Domain.Pessoas pessoas)
        {
            _context.Pessoas.Add(pessoas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoas", new { id = pessoas.Id }, pessoas);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Pessoas>> DeletePessoas(Guid id)
        {
            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }

            _context.Pessoas.Remove(pessoas);
            await _context.SaveChangesAsync();

            return pessoas;
        }

        private bool PessoasExists(Guid id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }

        [HttpGet("{id}/Amigos")]
        public async Task<ActionResult> GetAmigos([FromRoute] Guid id)
        {
            var pessoa = await _context.Pessoas.Include(x => x.Amigos).FirstOrDefaultAsync(x => x.Id == id);

            if (pessoa == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<List<PessoasResponse>>(pessoa.Amigos);

            return Ok(response);
        }

        [HttpPost("{id}/Amigos")]
        public async Task<ActionResult> PostAmigos([FromRoute] Guid id, [FromBody] PostAmigosRequest request)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            var amigos = await _context.Pessoas.Where(x => request.Ids.Contains(x.Id)).ToListAsync();

            pessoa.Amigos = amigos;

            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class PostAmigosRequest
    {
        public Guid[] Ids { get; set; }
    }
}
