using System;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

namespace SignalRBroker
{
	public class Global : HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			var hubConfiguration = new HubConfiguration { EnableCrossDomain = true };

			RouteTable.Routes.MapHubs(hubConfiguration);
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}