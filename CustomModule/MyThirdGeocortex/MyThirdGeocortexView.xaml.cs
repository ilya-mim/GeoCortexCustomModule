using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Geocortex.Essentials.Client;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Commands;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Diagnostics;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Events;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.UIComponents;
using Microsoft.Practices.Prism.Events;

namespace CustomModule.MyThirdGeocortex
{
    [Export]
    public partial class MyThirdGeocortexView : UserControl, IPartImportsSatisfiedNotification
    {
        ////Uncomment the lines below to get access to the global Site object.
        //[Import]
        //public Site Site { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public MyThirdGeocortexView()
        {
            InitializeComponent();          
        }

        public void OnImportsSatisfied()
        {
            EventAggregator.GetEvent<SiteInitializedEvent>().Subscribe(SiteInitialized);
        }

        public void SiteInitialized(SiteInitializedEventArgs args)
        {
            ViewCommands.ActivateView.Execute("MyThirdGeocortexView");

            var speedButtons = new ObservableCollection<SpeedButton>();
            speedButtons.Add(new SpeedButton() { Command = ViewCommands.HideView, CommandParameter = "MyThirdGeocortexView", ImageUri = "/Resources/Images/PanelClose.png", ToolTip = "Close" });

            ShellCommands.BringToFront.Execute(this);

            //Trace.TraceDebug("MyThirdGeocortexModule: Site Initialized and View successfully activated");
        }
    }
}