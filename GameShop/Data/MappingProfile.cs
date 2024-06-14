using AutoMapper;
using GameShop.Models.Entities;
using GameShop.Models.ViewModels;

namespace GameShop.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameVm>();
            CreateMap<GameVm, Game>()
                .ForMember(x => x.Description, opt => opt.Ignore()).ReverseMap();
        }
    }
}
