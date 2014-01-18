using Geocortex.EssentialsSilverlightViewer.Infrastructure.Configuration;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Diagnostics;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace CustomModule.MyThirdGeocortex
{
    [ModuleExport(typeof(MyThirdGeocortexModule))]
    public class MyThirdGeocortexModule : ViewerModule
    {
        protected override void Initialize(ModuleConfiguration moduleConfiguration)
        {
            base.Initialize(moduleConfiguration);

            //Initialize your module here.

            //Trace.TraceDebug("MyThirdGeocortexModule: Module successfully initialized");
        }
    }
}
