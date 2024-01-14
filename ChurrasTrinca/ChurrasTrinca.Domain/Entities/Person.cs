﻿using System.ComponentModel;

namespace ChurrasTrinca.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsCoOwner { get; set; }
        public IEnumerable<Invite> Invites { get; set; }


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

        public Person() {
        }

        public Person GerarPessoa()
        {
            Random random = new Random();
            Random random2 = new Random();

            int numeroAleatorio = random.Next(1, 10);
            int numPessoa = random2.Next(2, 50);

            Name = nomes[numPessoa];
            IsVegetarian = numeroAleatorio < 4 ? true : false;
            return this;
        }
    }
}