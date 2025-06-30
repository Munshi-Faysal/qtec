using Microsoft.EntityFrameworkCore;
using qtec.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.infrastructure.Persistence
{
    public class QtecDbContext : DbContext
    {
        public QtecDbContext(DbContextOptions<QtecDbContext> options) : base(options) { }

        public QtecDbContext()
        {
               
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<TblJournal> Journals { get; set; }
        public DbSet<JournalDetail> JournalDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JournalDetail>()
                .HasOne(jd => jd.Account)
                .WithMany(a => a.JournalDetails)
                .HasForeignKey(jd => jd.AccountsId)
                .OnDelete(DeleteBehavior.Restrict);  // or Cascade if desired

            modelBuilder.Entity<JournalDetail>()
                .HasOne(jd => jd.TblJournals)
                .WithMany(j => j.Details)
                .HasForeignKey(jd => jd.JournalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
