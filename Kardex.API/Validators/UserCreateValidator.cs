using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators
{
    public class UserCreateValidator
    {
        private readonly KardexContext _context;
        private UserDTO _user;

        public UserCreateValidator(KardexContext context, UserDTO user)
        {
            _context = context;
            _user = user;
        }

        public bool UserExists()
        {
            var userExists = _context.User.Where(user => user.Email == _user.Email)
                                          .Count();

            return (userExists > 0) ? false : true;
        }
    }
}
