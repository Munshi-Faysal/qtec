using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using qtec.application.Accounts.Commands.CreateAccount;
using qtec.application.Accounts.Queries.GetAccounts;
using qtec.shared.RequestModel;


namespace qtec.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<AccountDto>>> Get()
        {
            var accounts = await _mediator.Send(new GetAccountsQuery());
            return Ok(accounts);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateAccountRequest request)
        {
            var command = _mapper.Map<CreateAccountCommand>(request);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("balances")]
        public async Task<IActionResult> GetBalances()
        {
            var result = await _mediator.Send(new GetAccountBalanceQuery());
            return Ok(result);
        }
    }
}
