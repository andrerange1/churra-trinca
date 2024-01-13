namespace ChurrasTrinca.Domain
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

            Status = Pessoas.Count >= 7 ? StatusChurrascoEnum.Agendado : StatusChurrascoEnum.Pendente;

            Random numPessoas = new Random();  
            
            int numeroAleatorio = numPessoas.Next(1, 10);
            for (int i = 0; i < numeroAleatorio; i++)
            {
                Pessoas.Add(new Pessoa().GerarPessoa());
            }

            return this;
        }
    }
}
