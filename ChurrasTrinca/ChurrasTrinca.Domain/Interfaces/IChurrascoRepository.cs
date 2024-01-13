namespace ChurrasTrinca.Domain
{
    public interface IChurrascoRepository
    {
        public Task<List<Churrasco>> GetAllAsync();
        public Churrasco GetAsync();

    }
}
