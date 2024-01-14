using ChurrasTrinca.Domain.Entities;
using ChurrasTrinca.Domain.Interfaces.Repositories;

namespace ChurrasTrinca.Infra.Repository
{
    public class ChurrascoRepository : IChurrascoRepository
    {
        public Task<List<Churrasco>> GetAllAsync()
        {
            return null;
        }

        public Churrasco GetAsync()
        {
            return GetMockChurrasco();
        }

        private Churrasco GetMockChurrasco()
        {
            var novo = new Churrasco().GerarChurrascoAleatorio();
            return novo;
        }
    }
}
