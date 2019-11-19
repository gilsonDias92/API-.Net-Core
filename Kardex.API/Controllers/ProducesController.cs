using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kardex.API.Models;
using AutoMapper;
using Kardex.API.DataTransferObjects;

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducesController : ControllerBase
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public ProducesController(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Produces
        [HttpGet]
        public IActionResult GetProduce()
        {
            var produces = _context.Produce
                .Include(p => p.Panel)
                .Include(p => p.Cardlists)
                .Select(_mapper.Map<Produce, ProduceDTO>);

            return Ok(produces);
        }

        // GET: api/Produces/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduce([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produce = await _context.Produce.FindAsync(id);

            if (produce == null)
            {
                return NotFound();
            }

            return Ok(produce);
        }

        // PUT: api/Produces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduce([FromRoute] int id, [FromBody] Produce produce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produce.Id)
            {
                return BadRequest();
            }

            _context.Entry(produce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduceExists(id))
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

        // POST: api/Produces
        [HttpPost]
        public async Task<IActionResult> PostProduce([FromBody] Produce produce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Produce.Add(produce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduce", new { id = produce.Id }, produce);
        }

        // DELETE: api/Produces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduce([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produce = await _context.Produce.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }

            _context.Produce.Remove(produce);
            await _context.SaveChangesAsync();

            return Ok(produce);
        }

        private bool ProduceExists(int id)
        {
            return _context.Produce.Any(e => e.Id == id);
        }
    }
}