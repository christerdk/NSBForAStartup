using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace NSBForAStartup.AccountsService.Domain.Model.Events
{
    public class UserCreatedEvent : IEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
