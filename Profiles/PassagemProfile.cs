using AutoMapper;
using FlightForYou.API.Data.Dtos;
using FlightForYou.API.Models;

namespace FlightForYou.API.Profiles
{
    public class PassagemProfile : Profile
    {

        public PassagemProfile()
        {
            CreateMap<PassagemDto, Passagem>();
            CreateMap<Passagem, PassagemDto>().ForMember(passagemdto => passagemdto.Pessoa, opt => opt
                                               .MapFrom(passagem => passagem.Pessoa));
        }
    }
}
