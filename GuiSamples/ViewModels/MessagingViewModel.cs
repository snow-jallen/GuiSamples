using GuiSamples.Wpf.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var dialogParameters = new DialogParameters();
            dialogParameters.Add("key", Title);
            ShowDialog = new DelegateCommand(() => dialogService.ShowDialog(nameof(SampleDialogViewModel), dialogParameters, (result)=>
            {
            }));

            MessagesReceived = new ObservableCollection<string>();
            eventAggregator.GetEvent<UserMessageEvent>().Subscribe((msg) =>
            {
                ValueFromForm = msg;
                MessagesReceived.Add(msg);
            });
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

        public ObservableCollection<string> MessagesReceived { get; private set; }

        private string valueFromForm;
        public string ValueFromForm
        {
            get { return valueFromForm; }
            set { SetProperty(ref valueFromForm, value); }
        }
    }
}
