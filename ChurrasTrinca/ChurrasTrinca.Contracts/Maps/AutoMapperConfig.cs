using AutoMapper;

namespace ChurrasTrinca.Contracts
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Config() => 
                new MapperConfiguration(config => 
                { 
                    config.AddProfile<MappingProfile>();
                });
    }
}
