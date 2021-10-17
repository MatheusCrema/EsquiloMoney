using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Extensions;
using Domain.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class IdentitiesController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public IdentitiesController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<IdentityResource>), 200)]
        public async Task<QueryResultResource<IdentityResource>> ListAsync([FromQuery] IdentitiesQueryResource query)
        {
            var resources = new QueryResultResource<IdentityResource>();

            var identitiesQuery = _mapper.Map<IdentitiesQueryResource, IdentitiesQuery>(query);
            var queryResult = await _identityService.ListAsync(identitiesQuery);

            resources = _mapper.Map<QueryResult<Identity>, QueryResultResource<IdentityResource>>(queryResult);

            return resources;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] UpdateIdentityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var identity = _mapper.Map<UpdateIdentityResource, Identity>(resource);
            var result = await _identityService.UpdateAsync(id, identity);

            if (!result.Success)
                return BadRequest(result.Message);

            return StatusCode(204);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveIdentityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var identity = _mapper.Map<SaveIdentityResource, Identity>(resource);
            var result = await _identityService.SaveAsync(identity);

            if (!result.Success)
                return BadRequest(result.Message);

            var identityResource = _mapper.Map<Identity, IdentityResource>(result.Identity);
            return Ok(identityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _identityService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return StatusCode(204);
        }



    }
}
