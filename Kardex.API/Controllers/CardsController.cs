using System;
using System.Collections.Generic;
using System.Linq;
using Kardex.API.ExtensionMethods.CardExtensionMethods;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kardex.API.Models;
using AutoMapper;
using Kardex.API.DataTransferObjects;
using Kardex.API.Interfaces.Services;
using Kardex.API.Contracts.Requests.Create;

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _services;

        public CardsController(ICardService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetCard()
        {
            var cards = _services.GetAll();

            if (cards.IsFailed)
                return BadRequest(cards.Errors);

            return Ok(cards);
        }


        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _services.GetOne(id);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result);
        }


        [HttpPost]
        public IActionResult PostCard([FromBody] CardDTO card)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _services.Insert(card);

            if (result.IsFailed)
                return BadRequest(result.Errors.ToList());

            return CreatedAtAction("GetUser", new { id = card.Id }, card);
        }


        [HttpPut("{id}")]
        public IActionResult PutCard(int id, CardCreateRequest cardContract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cardDTO = cardContract.ConvertCreateContactToCardDTO();

            if (id != cardDTO.Id)
                return BadRequest();

            var result = _services.Update(id, cardDTO);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _services.Delete(id);

            if (result.IsFailed)
                return BadRequest(result.Errors.ToString());

            return Ok(result);
        }
    }
}