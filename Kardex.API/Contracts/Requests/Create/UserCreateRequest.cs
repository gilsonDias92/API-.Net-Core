using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Contracts.Requests.Create
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "Campo não pode ser vazio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo não pode ser vazio")]
        public string Password { get; set; }
        public string Icon { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Panel> Panels { get; set; }
    }
}
