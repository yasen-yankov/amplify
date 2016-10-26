﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
		}

		private void Bootstrapper_Bootstrapped(object sender, EventArgs e)
		{
			RouteCollectionExtensions.MapRoute(System.Web.Routing.RouteTable.Routes,
				 "Classic",
				 "amp/{ampPage}/{*itemUrl}",
				 new
				 {
				 	controller = "AmpPage",
					action = "Index",
					ampPage = (string)null,
					itemUrl = (string)null
				 }
			 );
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