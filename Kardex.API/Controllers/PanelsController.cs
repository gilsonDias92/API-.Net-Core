using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kardex.API.Models;
using AutoMapper;

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly KardexContext _context;

        public PanelsController(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Panels
        [HttpGet]
        public IEnumerable<Panel> GetPanel()
        {
            return _context.Panel;
        }

        // GET: api/Panels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPanel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var panel = await _context.Panel.FindAsync(id);

            if (panel == null)
            {
                return NotFound();
            }

            return Ok(panel);
        }

        // PUT: api/Panels/5
        [HttpPut("{id}")]
                // POST: api/Panels
        [HttpPost]
        public async Task<IActionResult> PostPanel([FromBody] Panel panel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Panel.Add(panel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanel", new { id = panel.Id }, panel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePanel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var panel = await _context.Panel.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }

            _context.Panel.Remove(panel);
            await _context.SaveChangesAsync();

            return Ok(panel);
        }
    }
}