using Geocortex.EssentialsSilverlightViewer.Infrastructure.Configuration;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Diagnostics;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace CustomModule.MyFirstGeocortex
{
    [ModuleExport(typeof(MyFirstGeocortexModule))]
    public class MyFirstGeocortexModule : ViewerModule
    {
        protected override void Initialize(ModuleConfiguration moduleConfiguration)
        {
            base.Initialize(moduleConfiguration);

            //Initialize your module here.

            //Trace.TraceDebug("MyFirstGeocortexModule: Module successfully initialized");
        }
    }
}
