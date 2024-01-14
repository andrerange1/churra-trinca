using AutoMapper;
using ChurrasTrinca.Domain;
using ChurrasTrinca.Domain.Entities;


namespace ChurrasTrinca.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Churrasco, ChurrascoResponse>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));


            CreateMap<PessoaResponse, Pessoa>().ReverseMap();
        }
    }
}
