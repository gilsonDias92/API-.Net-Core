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
    public class CardListsController : ControllerBase
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public CardListsController(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CardLists
        [HttpGet]
        public IActionResult GetCardList()
        {
            var cardLists = _context.CardList
                .Include(cl => cl.Produce)
                .Include(cl => cl.Cards)
                .Select(_mapper.Map<CardList, CardListDTO>);

            return Ok(cardLists);
        }

        // GET: api/CardLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cardList = await _context.CardList.FindAsync(id);

            if (cardList == null)
            {
                return NotFound();
            }

            return Ok(cardList);
        }

        // PUT: api/CardLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardList([FromRoute] int id, [FromBody] CardList cardList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardList.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardListExists(id))
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

        // POST: api/CardLists
        [HttpPost]
        public async Task<IActionResult> PostCardList([FromBody] CardList cardList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CardList.Add(cardList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardList", new { id = cardList.Id }, cardList);
        }

        // DELETE: api/CardLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cardList = await _context.CardList.FindAsync(id);
            if (cardList == null)
            {
                return NotFound();
            }

            _context.CardList.Remove(cardList);
            await _context.SaveChangesAsync();

            return Ok(cardList);
        }

        private bool CardListExists(int id)
        {
            return _context.CardList.Any(e => e.Id == id);
        }
    }
}