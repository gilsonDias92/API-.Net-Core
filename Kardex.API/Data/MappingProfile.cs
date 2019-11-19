using AutoMapper;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;

namespace Kardex.API.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>().ForMember(u => u.Id, opt => opt.Ignore());

            CreateMap<Card, CardDTO>();
            CreateMap<CardDTO, Card>().ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<CardList, CardListDTO>();
            CreateMap<CardListDTO, CardList>().ForMember(cl => cl.Id, opt => opt.Ignore());

            CreateMap<Produce, ProduceDTO>();
            CreateMap<ProduceDTO, Produce>().ForMember(p => p.Id, opt => opt.Ignore());

            CreateMap<Board, BoardDTO>();
            CreateMap<BoardDTO, Board>().ForMember(b => b.Id, opt => opt.Ignore());

            CreateMap<Panel, PanelDTO>();
            CreateMap<PanelDTO, Panel>().ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}
