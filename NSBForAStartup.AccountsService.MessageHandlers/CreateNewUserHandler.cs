using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSBForAStartup.AccountsService.Commands;
using NSBForAStartup.AccountsService.Domain.Model.Events;
using NServiceBus;

namespace NSBForAStartup.AccountsService.MessageHandlers
{
    /// <summary>
    ///This Account service handler simulates creation of a new user, which publishes an event
    ///after creation. This would preferrably be done as part of domain model 
    ///manipulation.
    /// </summary>
    public class CreateNewUserHandler : IHandleMessages<CreateNewUserCommand>
    {
        public IBus Bus { get; set; }
        
        public void Handle(CreateNewUserCommand message)
        {
            Debug.WriteLine("AccountsService: Creating new user...");
            Bus.Publish(new UserCreatedEvent
                {
                    UserId = message.UserId,
                    Email = message.Email
                });
        }
    }
}
