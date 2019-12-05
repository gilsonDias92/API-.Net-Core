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
using Kardex.API.ExtensionMethods.UserExtensionMethods;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.Services;
using Kardex.API.Interfaces.Services;
using FluentResults;
using Kardex.API.Validators.Rules.User;

namespace Kardex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _services;

        public UsersController(IUserService services)
        {
            _services = services;
        }


        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _services.GetAll();

            if (users.IsFailed)
                return BadRequest(users.Errors);

            return Ok(users);
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _services.GetOne(id);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserCreateRequest userContract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = userContract.ConvertCreateContractToUser();

            var result = _services.Update(id, user);

            if (result.IsFailed)
                return BadRequest(result.Errors);
            return Ok(result);
        }


        [EnableCors("MyPolicy")]
        [HttpPost]
        public IActionResult PostUser([FromBody]UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _services.Insert(user);

            if (result.IsFailed)
                return BadRequest(result.Errors.ToList());

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _services.Delete(id);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result.Errors.ToList());
        }
    }
}