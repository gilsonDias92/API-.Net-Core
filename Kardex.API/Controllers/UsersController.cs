using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using Kardex.API.Models;
using Kardex.API.Validators;
using Kardex.API.DataTransferObjects;
using Kardex.API.ExtensionMethods.User;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.Services;

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserServices _services;

        public UsersController(UserServices services)
        {
            _services = services;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _services.GetAll();
            return Ok(users);
        }

        // GET: api/Users/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_services.GetOne(id));
        }

        // PUT: api/Users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _services.Edit(id, userDTO);
            return Ok();
        }

        // POST: api/Users
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]UserCreateRequest userContract)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var _validator = new UserCreateRequestValidator(_context, userContract); 

            //if (!_validator.UserExists())
            //    return BadRequest(new { errors = "Erro! Esse e-mail já foi cadastrado." });


            //// Convertendo o contrato para DTO
            //var userDTO = userContract.ConvertContractToUserDTO();

            //var user = _mapper.Map<UserDTO, User>(userDTO);

            //_context.User.Add(user);
            //await _context.SaveChangesAsync();

            //userDTO.Id = user.Id;

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return Ok();
        }

        // DELETE: api/Users/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _services.Delete(id);

            return Ok();
        }
    }
}