using AutoMapper;
using GameShop.Models.Entities;
using GameShop.Models.ViewModels;

namespace GameShop.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameVm>()
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name)); ;
            CreateMap<GameVm, Game>()
                .ForMember(x => x.Description, opt => opt.Ignore()).ReverseMap();

            CreateMap<Genre, GenreVm>();
            CreateMap<GenreVm, Genre>()
                .ForMember(x => x.Games, opt => opt.Ignore()).ReverseMap();
        }
    }
}
