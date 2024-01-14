using ChurrasTrinca.Domain.Entities;

namespace ChurrasTrinca.Domain.Interfaces.Repositories
{
    public interface IChurrascoRepository
    {
        public Task<List<Bbq>> GetAllAsync();
        public Bbq GetAsync();

    }
}
