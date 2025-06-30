using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace qtec.shared.RequestModel
{
    public class CreateJournalRequest
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<JournalDetailRequest> Details { get; set; }
    }

    public class JournalDetailRequest
    {
        public int? AccountsId { get; set; }
        public decimal? DebitAmt { get; set; }
        public decimal? CreditAmt { get; set; }


    }
}
