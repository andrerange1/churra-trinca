namespace ChurrasTrinca.Domain.Entities
{
    public class Bbq
    {
        public DateTime DataChurrasco { get; set; }
        public BbqStatusEnum Status { get; set; }
        public IList<Person> Pessoas { get; set; }

        public Bbq() { }

        public Bbq GerarChurrascoAleatorio()
        {
            DataChurrasco = DateTime.UtcNow.AddDays(10);

            Random numPessoas = new Random();  
            
            int numeroAleatorio = numPessoas.Next(1, 10);

            if(Pessoas == null)
            {
                Pessoas = new List<Person>();
            }

            for (int i = 0; i < numeroAleatorio; i++)
            {
                Pessoas.Add(new Person().GerarPessoa());
            }

            Status = Pessoas.Count >= 7 ? BbqStatusEnum.Confirmed : BbqStatusEnum.PendingConfirmations;

            return this;
        }
    }
}
