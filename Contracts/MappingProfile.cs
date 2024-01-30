using AutoMapper;
using Domain.Entities;
using static Contracts.RunCreateNewBbq;


namespace Contracts
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Bbq, NewBbqRequest>().ReverseMap();

            CreateMap<Bbq, NewBbqResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Bbq, BbqResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.MeatAmount, opt => opt.MapFrom(src => src.MeatAmount.ToString("F2") + "Kg"))
                .ForMember(dest => dest.VegetablesAmount, opt => opt.MapFrom(src => src.VegetablesAmount.ToString("F2") + "Kg"));

            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<Person, NewPersonResponse>().ReverseMap();

            CreateMap<Invite, InviteResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<InviteResponse, Invite>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<InviteStatus>(src.Status)));

            CreateMap<NewLookupRequest, Lookups>()
            .ForMember(dest => dest.ModeratorIds, opt => opt.MapFrom(src => new List<string>()))
            .ForMember(dest => dest.PeopleIds, opt => opt.MapFrom(src => new List<string>()));

            CreateMap<Lookups, NewLookupResponse>()
            .ForMember(dest => dest.ModeratorId, opt => opt.MapFrom(src => src.ModeratorIds.FirstOrDefault()));

            CreateMap<LookupResponse, Lookups>().ReverseMap();
        }
    }
}
