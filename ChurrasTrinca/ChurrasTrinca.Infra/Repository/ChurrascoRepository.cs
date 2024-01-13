using ChurrasTrinca.Domain.Entities;
using ChurrasTrinca.Domain.Interfaces;

namespace ChurrasTrinca.Infra.Repository
{
    public class ChurrascoRepository : IChurrascoRepository
    {
        private readonly IChurrascoRepository _repository;

        public ChurrascoRepository(IChurrascoRepository repository)
        {
            _repository = repository;    
        }

        public Task<List<Churrasco>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Churrasco GetAsync()
        {
            return GetMockChurrasco();
        }

        private Churrasco GetMockChurrasco()
        {
            return new Churrasco().GerarChurrascoAleatorio();
        }
    }
}
