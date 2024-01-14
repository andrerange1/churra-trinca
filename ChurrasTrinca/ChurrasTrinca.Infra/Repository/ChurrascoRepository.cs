using ChurrasTrinca.Domain.Entities;
using ChurrasTrinca.Domain.Interfaces.Repositories;

namespace ChurrasTrinca.Infra.Repository
{
    public class ChurrascoRepository : IChurrascoRepository
    {
        public Task<List<Bbq>> GetAllAsync()
        {
            return null;
        }

        public Bbq GetAsync()
        {
            return GetMockChurrasco();
        }

        private Bbq GetMockChurrasco()
        {
            var novo = new Bbq().GerarChurrascoAleatorio();
            return novo;
        }
    }
}
