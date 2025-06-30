using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Accounts.Queries.GetAccounts
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class AccountBalanceDto
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal TotalBalance => TotalDebit - TotalCredit;
    }
}
