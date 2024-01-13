using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.Domain.Entities
{
    public class Churrasco
    {
        public IEnumerable<Pessoa> Pessoas { get; set; }
    }
}
