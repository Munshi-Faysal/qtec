using AutoMapper;
using qtec.application.Accounts.Commands.CreateAccount;
using qtec.application.Accounts.Queries.GetAccounts;
using qtec.application.Journal.Queries.GetJournals;
using qtec.domain.Entities;
using qtec.shared.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<CreateAccountRequest, CreateAccountCommand>();

            CreateMap<JournalDetail, JournalDetailDto>().ReverseMap();
            CreateMap<TblJournal, JournalDto>().ReverseMap();

            CreateMap<AccountWithDetails, AccountBalanceDto>();
        }
    }
}
