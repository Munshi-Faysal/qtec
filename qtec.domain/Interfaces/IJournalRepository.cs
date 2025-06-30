using qtec.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.domain.Interfaces
{
    public interface IJournalRepository
    {
        Task<int> CreateJournalAsync(TblJournal journal);
        Task<List<TblJournal>> GetAllAsync();
    }
}
