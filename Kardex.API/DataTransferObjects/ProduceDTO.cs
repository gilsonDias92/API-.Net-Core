using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class ProduceDTO
    {
        public int Id { get; set; }
        public PanelDTO Panel { get; set; }
        public int PanelId { get; set; }
        public ICollection<CardListDTO> Cardlists { get; set; }
    }
}
