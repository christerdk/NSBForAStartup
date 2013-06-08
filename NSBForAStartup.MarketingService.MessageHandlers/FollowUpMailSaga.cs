using System;
using System.Diagnostics;
using NSBForAStartup.AccountsService.Domain.Model.Events;
using NServiceBus.Saga;

namespace NSBForAStartup.MarketingService.MessageHandlers
{
    /// <summary>
    ///This saga shows how the Marketing department can decide to send 
    ///a follow up mail af a new user joins. In this example after 1 minute.
    /// </summary>
    public class FollowUpMailSaga : Saga<FollowUpMailSagaData>,
                                    IAmStartedByMessages<UserCreatedEvent>,
                                    IHandleTimeouts<FollowUpTimeout>
    {

        public void Handle(UserCreatedEvent message)
        {
            Data.UserId = message.UserId;
            Data.Email = message.Email;
            RequestUtcTimeout<FollowUpTimeout>(DateTime.Now.AddMinutes(1));
            Debug.WriteLine("MarketingService: New user " + Data.Email);
        }

        public void Timeout(FollowUpTimeout state)
        {
            Debug.WriteLine("MarketingService: Send follow up mail to " + Data.Email);
        }

        
    }

    public class FollowUpMailSagaData : IContainSagaData
    {
        [Unique]
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
    }

    public class FollowUpTimeout
    {

    }

}