namespace ChurrasTrinca.Domain.Entities
{
    public class Churrasco
    {
        public DateTime DataChurrasco { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusChurrascoEnum Status { get; set; }
        public IList<Pessoa> Pessoas { get; set; }

        public Churrasco() { }


        public Churrasco GerarChurrascoAleatorio()
        {
            DataCriacao = DateTime.UtcNow;
            DataChurrasco = DataCriacao.AddDays(10);

            Random numPessoas = new Random();  
            
            int numeroAleatorio = numPessoas.Next(1, 10);

            if(Pessoas == null)
            {
                Pessoas = new List<Pessoa>();
            }

            for (int i = 0; i < numeroAleatorio; i++)
            {
                Pessoas.Add(new Pessoa().GerarPessoa());
            }

            Status = Pessoas.Count >= 7 ? StatusChurrascoEnum.Agendado : StatusChurrascoEnum.Pendente;

            return this;
        }
    }
}
