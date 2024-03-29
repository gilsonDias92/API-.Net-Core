﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Icon { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
        public ICollection<PanelDTO> Panels { get; set; }
    }
}
