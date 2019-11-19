using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Contracts.Requests.Create
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Formato inválido")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
