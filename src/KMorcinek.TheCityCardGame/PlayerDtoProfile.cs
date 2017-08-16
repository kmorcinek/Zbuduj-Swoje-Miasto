using AutoMapper;

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