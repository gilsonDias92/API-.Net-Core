using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class PanelDTO
    {
        public int Id { get; set; }
        public BoardDTO Board { get; set; }
        public int BoardId { get; set; }
    }
}
