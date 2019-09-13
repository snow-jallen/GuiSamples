using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.Wpf.ViewModels
{
    public class SampleDialogViewModel : BindableBase, IDialogAware
    {
        public SampleDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(() => RequestClose?.Invoke(new DialogResult()));
        }

        public DelegateCommand CloseDialogCommand { get; }

        public event Action<IDialogResult> RequestClose;
        private string title = "Sample Dialog ViewModel";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
