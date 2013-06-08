
namespace NSBForAStartup.Worker 
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/profiles-for-nservicebus-host
	*/
    [EndpointName("NSBForAStartup.worker")]
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
	    public void Init()
	    {
            Configure.With().
               DefaultBuilder()
               .UnicastBus()
               .LoadMessageHandlers()
               .MsmqTransport()
               ;
        }
    }
}