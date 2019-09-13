using GuiSamples.Wpf.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.Wpf.ViewModels
{
    public class ValidatingFormViewModel : BindableBase
    {
        public ValidatingFormViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            NavigateToMessaging = new DelegateCommand<string>((uri) =>
            {
                regionManager.RequestNavigate("ContentRegion", uri);
            });
        }
        private string title = "Validing Form ViewModel";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string userValue;
        public string UserValue
        {
            get { return userValue; }
            set
            {
                SetProperty(ref userValue, value);
                eventAggregator.GetEvent<UserMessageEvent>().Publish(userValue);
            }
        }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public DelegateCommand<string> NavigateToMessaging { get; }
    }
}
