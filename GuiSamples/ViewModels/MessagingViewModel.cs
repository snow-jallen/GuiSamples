using GuiSamples.Wpf.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.Wpf.ViewModels
{
    public class MessagingViewModel : BindableBase
    {
        public MessagingViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            ShowDialog = new DelegateCommand(() => dialogService.ShowDialog(nameof(SampleDialogViewModel), null, null));

            eventAggregator.GetEvent<UserMessageEvent>().Subscribe((msg) => ValueFromForm = msg);
        }

        private string title = "Messaging ViewModel";
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        private readonly IEventAggregator eventAggregator;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand ShowDialog { get; }

        private string valueFromForm;
        public string ValueFromForm
        {
            get { return valueFromForm; }
            set { SetProperty(ref valueFromForm, value); }
        }
    }
}
