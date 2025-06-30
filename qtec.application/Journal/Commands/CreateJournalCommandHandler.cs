using MediatR;
using qtec.domain.Entities;
using qtec.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Journal.Commands
{
    public class CreateJournalCommandHandler : IRequestHandler<CreateJournalCommand, int>
    {
        private readonly IJournalRepository _repo;

        public CreateJournalCommandHandler(IJournalRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateJournalCommand request, CancellationToken cancellationToken)
        {
            var journal = new TblJournal
            {
                Date = request.Date,
                Description = request.Description,
                Details = request.Details.Select(d => new JournalDetail
                {
                    AccountsId = d.AccountsId,
                    DebitAmt = d.DebitAmt,
                    CreditAmt = d.CreditAmt
                }).ToList()
            };

            return await _repo.CreateJournalAsync(journal);
        }
    }
}
