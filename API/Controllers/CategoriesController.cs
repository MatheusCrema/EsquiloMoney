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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            //var result = isCascadeDelete ? await _categoryService.DeleteAsync(id) : await _categoryService.DeleteCascadeAsync(id);
            var result = await _categoryService.DeleteCascadeAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }


        [HttpGet("{id}")]
        public async Task<CategoryResource> ListAsync(int id)
        {
            var queryResult = await _categoryService.FindByIdAsync(id);

            var resource = _mapper.Map<Category, CategoryResource>(queryResult);

            return resource;
        }


        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<CategoryResource>), 200)]
        public async Task<QueryResultResource<CategoryResource>> ListAsync([FromQuery] CategoriesQueryResource query)
        {
            var resources = new QueryResultResource<CategoryResource>();

            var categoriesQuery = _mapper.Map<CategoriesQueryResource, CategoriesQuery>(query);
            var queryResult = await _categoryService.ListAsync(categoriesQuery);
            resources = _mapper.Map<QueryResult<Category>, QueryResultResource<CategoryResource>>(queryResult);

            return resources;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] UpdateCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<UpdateCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

    }
}
