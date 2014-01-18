using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Geocortex.Essentials.Client;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Commands;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Diagnostics;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.Events;
using Geocortex.EssentialsSilverlightViewer.Infrastructure.UIComponents;
using Microsoft.Practices.Prism.Events;

namespace CustomModule.MySecondGeocortex
{
    [Export]
    public partial class MySecondGeocortexView : MultiViewContentBase, IPartImportsSatisfiedNotification
    {
        ////Uncomment the lines below to get access to the global Site object.
        //[Import]
        //public Site Site { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public MySecondGeocortexView()
        {
            InitializeComponent();          
        }

        public void OnImportsSatisfied()
        {
            EventAggregator.GetEvent<SiteInitializedEvent>().Subscribe(SiteInitialized);
        }

        public void SiteInitialized(SiteInitializedEventArgs args)
        {

            /*   This section contains configuration enabled by inheriting from MultiViewContentBase.
             * 
             *   If not using the display frame on the right (the DataRegion) you may remove this configuation.
             *   Your View should also be altered to inherit from UserControl instead in this case. 
             *   Change this configuration at the top of this file, _and_ at the top of the ...View.xaml file.
             * 
             *   Or alternatively, create a new UserControl in the project for your new view,  
             *   name it appropriately (the name _must_ end in View) and copy the relevant config into it.
             *   It is allowed to have more than one View associated with a single Module.       */


            ViewCommands.ActivateView.Execute("MySecondGeocortexView");

            this.IsSelectable = true;
            this.Title = "MySecondGeocortex";
            this.Tooltip = Title;
            this.IsSelectable = true;
            this.LargeIconUri = "/Resources/Images/DefaultResult.png";
            this.SmallIconUri = LargeIconUri;
            this.Busy = false;

            var speedButtons = new ObservableCollection<SpeedButton>();
            speedButtons.Add(new SpeedButton() { Command = ViewCommands.HideView, CommandParameter = "MySecondGeocortexView", ImageUri = "/Resources/Images/PanelClose.png", ToolTip = "Close" });

            this.SpeedButtons = speedButtons;

            ShellCommands.BringToFront.Execute(this);

            //Trace.TraceDebug("MySecondGeocortexModule: Site Initialized and View successfully activated");
        }
    }
}