using Geocortex.EssentialsSilverlightViewer.Infrastructure.Configuration;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Diagnostics;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace CustomModule.MySecondGeocortex
{
    [ModuleExport(typeof(MySecondGeocortexModule))]
    public class MySecondGeocortexModule : ViewerModule
    {
        protected override void Initialize(ModuleConfiguration moduleConfiguration)
        {
            base.Initialize(moduleConfiguration);

            //Initialize your module here.

            //Trace.TraceDebug("MySecondGeocortexModule: Module successfully initialized");
        }
    }
}
