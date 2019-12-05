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
                .Include(cl => cl.Cards)
                .Select(_mapper.Map<CardList, CardListDTO>);

            return Ok(cardLists);
        }

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
    }
}