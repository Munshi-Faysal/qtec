using MediatR;
using qtec.application.Journal.Queries.GetJournals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Journal.Commands
{
    public class CreateJournalCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<JournalDetailDto> Details { get; set; }
    }
}
