using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ILookupsRepository : IStreamRepository<Lookups>
    {
        public Task<Lookups?> GetAsync(string id);
        public Task SaveOnDb(Lookups lookup);
    }
}
