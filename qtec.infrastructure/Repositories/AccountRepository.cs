using Microsoft.EntityFrameworkCore;
using qtec.domain.Entities;
using qtec.domain.Interfaces;
using qtec.infrastructure.Persistence;
using qtec.shared.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly QtecDbContext _context;

        public AccountRepository(QtecDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }


        public async Task<List<AccountWithDetails>> GetAccountBalancesAsync()
        {
            return await _context.Accounts
                .Select(a => new AccountWithDetails
                {
                    AccountId = a.Id,
                    AccountName = a.Name,
                    Type = a.Type,
                    TotalDebit = _context.JournalDetails
                        .Where(d => d.AccountsId == a.Id)
                        .Sum(d => (decimal?)d.DebitAmt) ?? 0,
                    TotalCredit = _context.JournalDetails
                        .Where(d => d.AccountsId == a.Id)
                        .Sum(d => (decimal?)d.CreditAmt) ?? 0
                })
                .ToListAsync();
        }
    }
}
