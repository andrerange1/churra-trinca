using AutoMapper;
using Contracts;

namespace Infra
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Config() => new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); });

    }
}
