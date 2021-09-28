using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IIdentityRepository
    {
        Task AddAsync(Identity identity);
        Task<QueryResult<Identity>> ListAsync(IdentitiesQuery query);
        Task<Identity> FindByIdAsync(int id);
        void Remove(Identity identity);

        void Update(Identity identity);
    }
}
