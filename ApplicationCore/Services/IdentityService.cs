using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services.Communication;
using Domain.Services;

namespace ApplicationCore.Services
{
    public class IdentityService : IIdentityService
    {

        private readonly IIdentityRepository _identityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IdentityService(IIdentityRepository identityRepository, IUnitOfWork unitOfWork)
        {
            _identityRepository = identityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IdentityResponse> DeleteAsync(int id)
        {
            var existingIdentity = await _identityRepository.FindByIdAsync(id);

            if (existingIdentity == null)
                return new IdentityResponse("Identity not found.");

            try
            {
                _identityRepository.Remove(existingIdentity);
                await _unitOfWork.CompleteAsync();

                return new IdentityResponse(existingIdentity);
            }
            catch (Exception ex)
            {
                return new IdentityResponse($"An error occurred when deleting the identity: {ex.Message}");
            }
        }

        public async Task<Identity> FindByIdAsync(int id)
        {
            return await _identityRepository.FindByIdAsync(id);
        }

        public async Task<QueryResult<Identity>> ListAsync(IdentitiesQuery query)
        {
            return await _identityRepository.ListAsync(query);
        }

        public async Task<IdentityResponse> SaveAsync(Identity identity)
        {
            try
            {
                await _identityRepository.AddAsync(identity);
                await _unitOfWork.CompleteAsync();

                return new IdentityResponse(identity);
            }
            catch (Exception ex)
            {
                return new IdentityResponse($"An error occured when saving the identity: {ex.Message} n/ {ex.StackTrace}");
            }
        }

        public async Task<IdentityResponse> UpdateAsync(int id, Identity identity)
        {
            var existingIdentity = await _identityRepository.FindByIdAsync(id);

            if (existingIdentity == null)
                return new IdentityResponse("Identity not found.");

            existingIdentity.FirstName = identity.FirstName ?? existingIdentity.FirstName;
            existingIdentity.LastName = identity.LastName ?? existingIdentity.LastName;
            existingIdentity.Email = identity.Email ?? existingIdentity.Email;
            existingIdentity.Phone = identity.Phone ?? existingIdentity.Phone;
            
            //foreach( existingIdentity.Accounts)

            try
            {
                _identityRepository.Update(existingIdentity);
                await _unitOfWork.CompleteAsync();

                return new IdentityResponse(existingIdentity);
            }
            catch (Exception ex)
            {
                return new IdentityResponse($"An error occurred when saving the Identity: {ex.Message} n/ {ex.StackTrace}");
            }
        }
    }
}
