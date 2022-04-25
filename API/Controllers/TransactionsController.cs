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
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<TransactionResource> ListAsync(int id)
        {
            var queryResult = await _transactionService.FindByIdAsync(id);

            var resource = _mapper.Map<Transaction, TransactionResource>(queryResult);

            return resource;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<TransactionResource>), 200)]
        public async Task<QueryResultResource<TransactionResource>> ListAsync([FromQuery] TransactionsQueryResource query)
        {
            var resources = new QueryResultResource<TransactionResource>();

            var transactionsQuery = _mapper.Map<TransactionsQueryResource, TransactionsQuery>(query);
            var queryResult = await _transactionService.ListAsync(transactionsQuery);
            resources = _mapper.Map<QueryResult<Transaction>, QueryResultResource<TransactionResource>>(queryResult);

            return resources;
        }

    }
}
