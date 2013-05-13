using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.SessionState;
using App_Code.Controls;
using BlogEngine.Core;

namespace Website.GRE
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Application_BeginRequest(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            // Attempt to perform first request initialization
            FirstRequestInitialization.Initialize(context);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        private class FirstRequestInitialization
        {
            private static bool _initializedAlready = false;
            private readonly static object _SyncRoot = new Object();

            // Initialize only on the first request
            public static void Initialize(HttpContext context)
            {
                if (_initializedAlready) { return; }

                lock (_SyncRoot)
                {
                    if (_initializedAlready) { return; }

                    WidgetZone.PreloadWidgetsAsync("be_WIDGET_ZONE");
                    Utils.LoadExtensions();

                    BundleConfig.RegisterBundles(BundleTable.Bundles);

                    _initializedAlready = true;
                }
            }
        }
    }
}
