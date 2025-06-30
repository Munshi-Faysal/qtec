using AutoMapper;
using MediatR;
using qtec.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Accounts.Queries.GetAccounts
{
    public class GetAccountBalanceQueryHandler : IRequestHandler<GetAccountBalanceQuery, List<AccountBalanceDto>>
    {
        private readonly IAccountRepository _queryService;
        private readonly IMapper _mapper;

        public GetAccountBalanceQueryHandler(IAccountRepository queryService, IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }

        public async Task<List<AccountBalanceDto>> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            var data = await _queryService.GetAccountBalancesAsync();
            return _mapper.Map<List<AccountBalanceDto>>(data);
        }
    }

}
