using ChurrasTrinca.Domain.Entities;
using ChurrasTrinca.Domain.Interfaces.Repositories;
using ChurrasTrinca.Domain.Interfaces.Services;

namespace ChurrasTrinca.Domain
{
    public class ChurrascoService : IChurrascoService
    {
        private readonly IChurrascoRepository _repository;

        public ChurrascoService(IChurrascoRepository repository)
        {
            _repository = repository;
        }
        public Bbq GetAsync()
        {
            return _repository.GetAsync();
        }
    }
}
