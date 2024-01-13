namespace ChurrasTrinca.Domain
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public bool ComeCarne { get; set; }


        List<string> nomes = new List<string>
        {
            "Ana", "Carlos", "Fernanda", "Lucas", "Mariana",
            "Pedro", "Renata", "Thiago", "Vanessa", "Vinícius",
            "Amanda", "Bruno", "Camila", "Daniel", "Eduarda",
            "Felipe", "Gabriela", "Henrique", "Isabela", "João",
            "Juliana", "Leonardo", "Luana", "Marcelo", "Natália",
            "Rafael", "Raquel", "Roberto", "Sofia", "Tiago",
            "Alice", "Arthur", "Beatriz", "Bernardo", "Clara",
            "Davi", "Emanuelly", "Enzo", "Giovanna", "Guilherme",
            "Helena", "Hugo", "Isabelly", "Joaquim", "Julia",
            "Lara", "Lorenzo", "Lívia", "Mateus", "Mariana",
            "Miguel", "Natalie", "Nicolas", "Nicole", "Paulo",
            "Rafaela", "Raul", "Sophia", "Theo", "Valentina",
            "Vitor", "Yasmin", "André", "Bianca", "Cauã",
            "Cecília", "Diego", "Emilly", "Erick", "Fernanda",
            "Francisco", "Gabriel", "Giovanni", "Isis", "Igor",
            "Júlio", "Kaline", "Kaique", "Larissa", "Luciano",
            "Luma", "Matheus", "Melissa", "Nathan", "Nina",
            "Oliver", "Paloma", "Pietro", "Rafaelly", "Ravi"
        };

        public Pessoa() {
        }

        public Pessoa GerarPessoa()
        {
            Random random = new Random();
            Random random2 = new Random();

            int numeroAleatorio = random.Next(1, 10);
            int numPessoa = random2.Next(1, 100);

            Nome = nomes[numPessoa];
            ComeCarne = numeroAleatorio > 4 ? true : false;
            return this;
        }
    }
}
