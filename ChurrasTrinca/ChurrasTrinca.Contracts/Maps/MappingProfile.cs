using AutoMapper;
using ChurrasTrinca.Domain;


namespace ChurrasTrinca.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChurrascoResponse, Churrasco>();
        }
    }
}
