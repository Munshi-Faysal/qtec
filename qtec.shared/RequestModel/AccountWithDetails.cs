using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.shared.RequestModel
{
    public class AccountWithDetails
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Type { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
    }
}
