﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class CardListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CardDTO> Cards { get; set; }
        public bool Creatable { get; set; }
    }
}
