using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators
{
    public class UserValidator
    {
        private KardexContext _context;
        private User _user;

        public UserValidator(KardexContext context, User user)
        {
            _context = context;
            _user = user;
        }

        public bool UserExists()
        {
            var userExists = _context.User.Where(u => u.Email == _user.Email)
                                          .Count();

            return (userExists > 0) ? false : true;
        }
    }
}
