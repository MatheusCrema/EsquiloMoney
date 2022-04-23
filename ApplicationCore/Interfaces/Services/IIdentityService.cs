using System.Threading.Tasks;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Services.Communication;

namespace ApplicationCore.Interfaces.Services
{
    public interface IIdentityService
    {

        Task<IdentityResponse> DeleteAsync(int id);

        Task<Identity> FindByIdAsync(int id);

        Task<QueryResult<Identity>> ListAsync(IdentitiesQuery query);

        Task<IdentityResponse> SaveAsync(Identity identity);

        Task<IdentityResponse> UpdateAsync(int id, Identity identity);

    }
}
