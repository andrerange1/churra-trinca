using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILookupService
    {
        public Task<Lookups> GetAsync(string id);
        public Task<Lookups> CreateNew(Lookups lookup);
        public Task<Lookups> AddPerson(string lookupId, string personId); //add a person to a lookup
    }
}
