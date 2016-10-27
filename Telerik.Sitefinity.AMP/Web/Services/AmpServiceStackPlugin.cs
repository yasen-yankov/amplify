using System;
using ServiceStack;
using Telerik.Sitefinity.AMP.Web.Services.Dto;

namespace Telerik.Sitefinity.AMP.Web.Services
{
    /// <summary>
    /// Represents a ServiceStack plug-in for Packaging service.
    /// </summary>
    internal class AmpServiceStackPlugin : IPlugin
    {
        /// <summary>
        /// Adds the Packaging service routes
        /// </summary>
        /// <param name="appHost">The service stack appHost</param>
        public void Register(IAppHost appHost)
        {
            if (appHost == null)
            {
                throw new ArgumentNullException("appHost");
            }

            appHost.RegisterService(typeof(AmpWebService), AmpServiceStackPlugin.AmpWebServiceRoute);
            appHost.Routes
                .Add<AmpPagesGetRequest>(AmpServiceStackPlugin.AmpPagesRoute, "GET")
                .Add<AmpPageInsertRequest>(AmpServiceStackPlugin.AmpPageInsertRoute, "PUT")
                .Add<AmpPageUpdateRequest>(AmpServiceStackPlugin.AmpPageUpdateRoute, "POST")
                .Add<AmpPageDeleteRequest>(AmpServiceStackPlugin.AmpPageDeleteRoute, "DELETE");
        }

        internal const string AmpWebServiceRoute = "/Sitefinity/amp";
        internal const string AmpPagesRoute = AmpServiceStackPlugin.AmpWebServiceRoute + "/pages";
        internal const string AmpPageInsertRoute = AmpServiceStackPlugin.AmpWebServiceRoute + "/pages";
        internal const string AmpPageUpdateRoute = AmpServiceStackPlugin.AmpWebServiceRoute + "/pages/{id}";
        internal const string AmpPageDeleteRoute = AmpServiceStackPlugin.AmpWebServiceRoute + "/pages/{id}";
    }
}