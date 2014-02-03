using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRBroker
{
	[HubName("random")]
	public class RandomHub : Hub
	{
		public void Do(string what)
		{
			Clients.Caller.say(what);
		}
	}
}