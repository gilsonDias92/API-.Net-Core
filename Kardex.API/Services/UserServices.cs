using AutoMapper;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;
using Microsoft.AspNetCore.Mvc;
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

        public void Delete(int id)
        {

        }

        public void Edit(User user)
        {

        }


    }
}
