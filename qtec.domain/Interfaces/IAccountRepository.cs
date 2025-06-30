using qtec.domain.Entities;
using qtec.shared.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> AddAsync(Account account);

        //Task<List<Account>> GetAccountsWithBalanceDataAsync();

        Task<List<AccountWithDetails>> GetAccountBalancesAsync();
    }
}
