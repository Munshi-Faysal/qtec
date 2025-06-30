using AutoMapper;
using MediatR;
using qtec.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Journal.Queries.GetJournals
{
    public class GetJournalQueryHandler : IRequestHandler<GetJournalQuery, List<JournalDto>>
    {
        private readonly IJournalRepository _repo;
        private readonly IMapper _mapper;

        public GetJournalQueryHandler(IJournalRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<JournalDto>> Handle(GetJournalQuery request, CancellationToken cancellationToken)
        {
            var journals = await _repo.GetAllAsync();
            return _mapper.Map<List<JournalDto>>(journals);
        }
    }
}
