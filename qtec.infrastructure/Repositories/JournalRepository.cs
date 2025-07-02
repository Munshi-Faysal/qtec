using Microsoft.EntityFrameworkCore;
using qtec.domain.Entities;
using qtec.domain.Interfaces;
using qtec.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.infrastructure.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly QtecDbContext _context;

        public JournalRepository(QtecDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateJournalAsync(TblJournal journal)
        {
            try
            {            
               _context.Journals.Add(journal);
                await _context.SaveChangesAsync();
                return journal.Id;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TblJournal>> GetAllAsync()
        {
            return await _context.Journals
                .Include(j => j.Details)
                .ToListAsync();
        }
    }
}
