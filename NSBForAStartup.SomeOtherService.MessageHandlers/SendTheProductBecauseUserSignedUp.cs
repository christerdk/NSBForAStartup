using System.Diagnostics;
using NSBForAStartup.AccountsService.Domain.Model.Events;
using NServiceBus;

namespace NSBForAStartup.ProductService.MessageHandlers
{
    /// <summary>
    /// For the sake of example, this simulates that the users is supposed to receive a
    /// product (e-book?) after joining. 
    /// Technically this shows multiple use of the same event (UserCreatedEvent).
    /// </summary>
    public class SendTheProductBecauseUserSignedUp : IHandleMessages<UserCreatedEvent>
    {
        public void Handle(UserCreatedEvent message)
        {
            Debug.WriteLine("ProductService: Sending some product...");
        }
    }
}
