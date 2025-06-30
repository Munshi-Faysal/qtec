using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<int>  // return created Account Id
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
