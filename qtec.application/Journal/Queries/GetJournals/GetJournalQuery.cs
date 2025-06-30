using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Journal.Queries.GetJournals
{
    public class GetJournalQuery : IRequest<List<JournalDto>> { }
}
