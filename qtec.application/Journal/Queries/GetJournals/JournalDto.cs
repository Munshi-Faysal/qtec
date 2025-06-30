using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Journal.Queries.GetJournals
{
    public class JournalDetailDto
    {
        public int AccountsId { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal CreditAmt { get; set; }
    }

    public class JournalDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<JournalDetailDto> Details { get; set; }
    }
}
