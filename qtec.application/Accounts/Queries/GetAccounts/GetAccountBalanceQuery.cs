using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Accounts.Queries.GetAccounts
{
    public class GetAccountBalanceQuery : IRequest<List<AccountBalanceDto>> { }

}
