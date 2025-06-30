using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.domain.Entities
{
    public class TblJournal
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public List<JournalDetail> Details { get; set; } = new();
    }
    // JournalDetail.cs
    public class JournalDetail
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public int AccountsId { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal CreditAmt { get; set; }

        public TblJournal TblJournals { get; set; }

        public Account Account { get; set; }
    }
}
