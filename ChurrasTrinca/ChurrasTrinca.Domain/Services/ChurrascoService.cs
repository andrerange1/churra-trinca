namespace ChurrasTrinca.Domain
{
    public class ChurrascoService : IChurrascoService
    {
        private readonly IChurrascoRepository _repository;

        public Churrasco GetAsync()
        {
            return _repository.GetAsync();
        }
    }
}
