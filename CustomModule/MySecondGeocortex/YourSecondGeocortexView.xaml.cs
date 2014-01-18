using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
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
    public partial class YourSecondGeocortexView : MultiViewContentBase, IPartImportsSatisfiedNotification
    {
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public YourSecondGeocortexView()
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


            ViewCommands.ActivateView.Execute("YourSecondGeocortexView");

            this.IsSelectable = true;
            this.Title = "YourSecondGeocortex";
            this.Tooltip = Title;
            this.IsSelectable = true;
            this.LargeIconUri = "/Resources/Images/DefaultResult.png";
            this.SmallIconUri = LargeIconUri;
            this.Busy = false;

            var speedButtons = new ObservableCollection<SpeedButton>();
            speedButtons.Add(new SpeedButton() { Command = ViewCommands.HideView, CommandParameter = "YourSecondGeocortexView", ImageUri = "/Resources/Images/PanelClose.png", ToolTip = "Close" });

            this.SpeedButtons = speedButtons;

            //ShellCommands.BringToFront.Execute(this);

            //Trace.TraceDebug("YourSecondGeocortexModule: Site Initialized and View successfully activated");
        }
    }
}
