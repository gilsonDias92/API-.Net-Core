using AutoMapper;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Services
{
    public class UserServices
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public UserServices(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _context.User.ToList()
                .Select(_mapper.Map<User, UserDTO>);
            return users;
        }

        public async Task<UserDTO> GetOne(int id)
        {
            var user = await _context.User.FindAsync(id);

            // if (user == null)
            //     return 

            return _mapper.Map<UserDTO>(user);
        }

        public async void Edit(int id, UserDTO user)
        {
            var userInDb = _context.User.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
                return;

            _mapper.Map(user, userInDb);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return;
                else
                    throw;
            }
        }

        public async void Delete(int id)
        {
            var userInDb = await _context.User.FindAsync(id);

            if (userInDb == null)
                return;

            _context.User.Remove(userInDb);
            await _context.SaveChangesAsync();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
