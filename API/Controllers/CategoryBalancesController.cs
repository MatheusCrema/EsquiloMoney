using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryBalancesController : Controller
    {
        private readonly ICategoryBalanceService _categoryBalanceService;
        private readonly IMapper _mapper;

        public CategoryBalancesController(ICategoryBalanceService categoryBalanceService, IMapper mapper)
        {
            _categoryBalanceService = categoryBalanceService;
            _mapper = mapper;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryBalanceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryBalanceResource = _mapper.Map<CategoryBalance, CategoryBalanceResource>(result.CategoryBalance);

            return Ok(categoryBalanceResource);
        }


        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<CategoryBalanceResource>), 200)]
        public async Task<QueryResultResource<CategoryBalanceResource>> ListAsync([FromQuery] CategoryBalancesQueryResource query)
        {
            var categoryBalancesQuery = _mapper.Map<CategoryBalancesQueryResource, CategoryBalancesQuery>(query);
            var queryResult = await _categoryBalanceService.ListAsync(categoryBalancesQuery);

            var resources = _mapper.Map<QueryResult<CategoryBalance>, QueryResultResource<CategoryBalanceResource>>(queryResult);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryBalanceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var categoryBalance = _mapper.Map<SaveCategoryBalanceResource, CategoryBalance>(resource);
            var result = await _categoryBalanceService.SaveAsync(categoryBalance);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryBalanceResource = _mapper.Map<CategoryBalance, CategoryBalanceResource>(result.CategoryBalance);
            return Ok(categoryBalanceResource);
        }

    }
}
