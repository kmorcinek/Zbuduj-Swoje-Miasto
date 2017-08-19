using AutoMapper;
using KMorcinek.TheCityCardGame.SharedDtos;

namespace KMorcinek.TheCityCardGame
{
    public class PlayerDtoProfile : Profile
    {
        public PlayerDtoProfile()
        {
            CreateMap<Player, PlayerDto>();
        }
    }
}