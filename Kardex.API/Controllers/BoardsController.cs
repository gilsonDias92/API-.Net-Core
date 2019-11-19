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
    public class BoardsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly KardexContext _context;

        public BoardsController(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Boards
        [HttpGet]
        public IActionResult GetBoard()
        {
            var boards = _context.Board
                .Include(b => b.User)
                .Include(b => b.Panels)
                .Select(_mapper.Map<Board, BoardDTO>);

            return Ok(boards);
        }

        // GET: api/Boards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = await _context.Board.FindAsync(id);

            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // PUT: api/Boards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoard([FromRoute] int id, [FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.Id)
            {
                return BadRequest();
            }

            _context.Entry(board).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // POST: api/Boards
        [HttpPost]
        public async Task<IActionResult> PostBoard([FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Board.Add(board);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoard", new { id = board.Id }, board);
        }

        // DELETE: api/Boards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Board.Remove(board);
            await _context.SaveChangesAsync();

            return Ok(board);
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}