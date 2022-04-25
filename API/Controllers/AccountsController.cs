using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Interfaces.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<AccountResource> ListAsync(int id)
        {
            var queryResult = await _accountService.FindByIdAsync(id);

            var resource = _mapper.Map<Account, AccountResource>(queryResult);

            return resource;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<AccountResource>), 200)]
        public async Task<QueryResultResource<AccountResource>> ListAsync([FromQuery] AccountsQueryResource query)
        {
            var resources = new QueryResultResource<AccountResource>();

            var accountsQuery = _mapper.Map<AccountsQueryResource, AccountsQuery>(query);
            var queryResult = await _accountService.ListAsync(accountsQuery);
            resources = _mapper.Map<QueryResult<Account>, QueryResultResource<AccountResource>>(queryResult);

            return resources;
        }

    }
}
