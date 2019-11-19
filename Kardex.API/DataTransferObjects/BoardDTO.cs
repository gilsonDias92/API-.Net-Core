using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public ICollection<PanelDTO> Panels { get; set; }
    }
}
