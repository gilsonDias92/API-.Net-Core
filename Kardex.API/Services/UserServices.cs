using AutoMapper;
using FluentResults;
using FluentValidation;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using Kardex.API.ExtensionMethods.UserExtensionMethods;
using Kardex.API.Interfaces.Services;
using Kardex.API.Models;
using Kardex.API.Validators;
using Kardex.API.Validators.Rules.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Services
{
    public class UserServices : IUserService
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public UserServices(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<IEnumerable<UserDTO>> GetAll()
        {
            var users = _context.User
                //.Include(u => u.Cards)
                .Select(_mapper.Map<User, UserDTO>);

            if (users == null)
            {
                Result error = Results.Fail("Erro! Não há usuários cadastrados.");
            }
            return Results.Ok(users);
        }

        public Result<UserDTO> GetOne(int id)
        {
            var user = _context.User.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                Result error = Results.Fail("Erro! Usuário inválido.");
                return error;
            }
            var userDTO = _mapper.Map<User, UserDTO>(user);
            return Results.Ok(userDTO);
        }

        public Result Insert(UserDTO userDTO)
        {
            var validationRules = new UserModelValidatior();
            var validationResult = validationRules.Validate(userDTO);

            if (!validationResult.IsValid)
            {
                string errors = null;

                foreach (var failure in validationResult.Errors)
                {
                    errors += "Propriedade: " + failure.PropertyName + ". Erro: " +
                        failure.ErrorMessage + " .";
                }
                return Results.Fail(errors);
            }

            var userValidator = new UserCreateValidator(_context, userDTO);
            if (!userValidator.UserExists())
            {
                Result error = Results.Fail("Esse e-mail já foi cadastrado!");
                return error.Errors.ToResult();
            }
            var user = _mapper.Map<UserDTO, User>(userDTO);


            _context.User.Add(user);
            _context.SaveChanges();
            userDTO.Id = user.Id;

            return Results.Ok(user.Id);
        }

        public Result Update(int id, UserDTO userDTO)
        {
            var userInDb = _context.User
                .SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
            {
                Result error = Results.Fail("Usuário não encontrado!");
                return error;
            }

            _mapper.Map(userDTO, userInDb);

            var contextUpdated = _context.SaveChanges();

            if (contextUpdated > 0)
                return Results.Ok();
            else
                return Results.Fail("Ocorreu um erro na hora de salvar");
        }

        public Result Delete(int id)
        {
            var user = _context.User.SingleOrDefault(u => u.Id == id);

            if (!UserExists(user.Id))
            {
                return Results.Fail("Usuário não encontrado.");
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return Results.Ok();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
