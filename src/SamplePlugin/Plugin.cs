using System;
using Microsoft.Xrm.Sdk;

namespace SamplePlugin
{
    /// <summary>
    /// Sample Dataverse plugin that demonstrates the plugin interface.
    /// </summary>
    public class Plugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

            IOrganizationService service =
                serviceFactory.CreateOrganizationService(context.UserId);

            tracingService.Trace("SamplePlugin: Executing...");

            // Plugin logic goes here.

            tracingService.Trace("SamplePlugin: Execution complete.");
        }
    }
}
