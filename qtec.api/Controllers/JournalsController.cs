using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using qtec.application.Journal.Commands;
using qtec.application.Journal.Queries.GetJournals;
using qtec.shared.RequestModel;

namespace qtec.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JournalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateJournalRequest request)
        {
            var command = new CreateJournalCommand
            {
                Date = request.Date,
                Description = request.Description,
                Details = request.Details.Select(d => new JournalDetailDto
                {
                    AccountsId = d.AccountsId??0,
                    DebitAmt = d.DebitAmt ?? 0,
                    CreditAmt = d.CreditAmt ?? 0
                }).ToList()
            };

            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetJournalQuery());
            return Ok(result);
        }
    }
}
