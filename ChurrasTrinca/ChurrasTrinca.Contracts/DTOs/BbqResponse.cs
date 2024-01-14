using ChurrasTrinca.Domain;

namespace ChurrasTrinca.Contracts
{
    public class BbqResponse
    {
        public DateTime DataChurrasco { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public IList<PersonResponse> Pessoas { get; set; }
    }
}
