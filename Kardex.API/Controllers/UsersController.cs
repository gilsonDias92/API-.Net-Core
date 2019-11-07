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

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public UsersController(KardexContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _context.User.ToList()
                .Select(_mapper.Map<User, UserDTO>);

            return Ok(users);
        }

        // GET: api/Users/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _context.User.FindAsync(id);

            if (user == null)
                return BadRequest(error: "Erro! Usuário não encontrado.");

            return  Ok(_mapper.Map<UserDTO>(user));
        }

        // PUT: api/Users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userInDb = _context.User.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                return NotFound();

            _mapper.Map(userDTO, userInDb);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                else
                    throw;
            }

            return Ok();
        }

        // POST: api/Users
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]UserCreateRequest userContract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var _validator = new UserCreateRequestValidator(_context, userContract);    
            if (!_validator.UserExists())
                return BadRequest(new { errors = "Erro! Esse e-mail já foi cadastrado." });

            // Convertendo o contrato para DTO
            var userDTO = userContract.ConvertContractToUserDTO();

            // Mapeando a DTO para a model
            var user = _mapper.Map<UserDTO, User>(userDTO);

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            userDTO.Id = user.Id;

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userInDb = await _context.User.FindAsync(id);

            if (userInDb == null)
                return NotFound();

            _context.User.Remove(userInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}