using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NSBForAStartup.AccountsService.Commands
{
    public class CreateNewUserCommand  : ICommand
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
