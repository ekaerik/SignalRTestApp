using System;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace SignalRTestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Connecting");
			var connection = new HubConnection("http://localhost/SignalRBroker");
			connection.StateChanged += change => Console.WriteLine(Environment.NewLine + change.OldState + " => " + change.NewState);
			connection.Closed +=() =>
				{
					Console.WriteLine("Closed event triggered");
					Thread.Sleep(TimeSpan.FromSeconds(5));
					// BUG? If you use .Wait() it will not reconnect
					connection.Start().Wait();
					//connection.Start();
					Console.WriteLine("Connection is starting / Connection have started");
				};
			var proxy = connection.CreateHubProxy("random");
			connection.Start().Wait();

			Console.WriteLine("Start sending");
			for (var i = 0; i < 100000000; i++)
			{
				try
				{
					while (connection.State != ConnectionState.Connected)
					{
					}
					proxy.Invoke("do", "A simple string message");
					Console.Write(".");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			connection.Stop();
			Console.WriteLine("Done!");
			Console.ReadLine();
		}
	}
}
