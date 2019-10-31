using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Services
{
    public class UserServices
    {
        private readonly KardexContext _context;

        public UserServices(KardexContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(User user)
        {

        }


    }
}
