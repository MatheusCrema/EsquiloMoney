using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Queries;
using ApplicationCore.Entities.Resources;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Extensions;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _transactionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);

            return Ok(transactionResource);
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] UpdateTransactionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var transaction = _mapper.Map<UpdateTransactionResource, Transaction>(resource);
            var result = await _transactionService.UpdateAsync(id, transaction);

            if (!result.Success)
                return BadRequest(result.Message);

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);

            return Ok(transactionResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTransactionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var transaction = _mapper.Map<SaveTransactionResource, Transaction>(resource);
            var result = await _transactionService.SaveAsync(transaction);

            if (!result.Success)
                return BadRequest(result.Message);

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(result.Transaction);
            return Ok(transactionResource);
        }

    }
}
