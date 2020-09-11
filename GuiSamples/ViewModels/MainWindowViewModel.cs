using GuiSamples.Wpf.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GuiSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            Title = "Prism Application";
            this.regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
            DialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        private string title;
        private readonly IRegionManager regionManager;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private DelegateCommand launchClipboardManager;
        public DelegateCommand LaunchClipboardManager => launchClipboardManager ??= new DelegateCommand(
            () =>
            {
                DialogService.ShowDialog(nameof(ClipboardManagerViewModel), null, (result) =>
                {
                    if(result.Result == ButtonResult.OK)
                    {
                        ClipboardItems.Add(result.Parameters.GetValue<string>("item"));
                    }
                });
            });

        public IDialogService DialogService { get; }
        public ObservableCollection<string> ClipboardItems { get; private set; } = new ObservableCollection<string>();
    }
}
