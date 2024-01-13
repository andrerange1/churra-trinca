using ChurrasTrinca.Domain;

namespace ChurrasTrinca.Contracts
{
    public class ChurrascoResponse
    {
        public DateTime DataChurrasco { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusChurrascoEnum Status { get; set; }
        public IList<PessoaResponse> Pessoas { get; set; }
    }
}
