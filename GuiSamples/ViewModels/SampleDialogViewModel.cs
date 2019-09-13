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

        }

        private string title = "Sample Dialog ViewModel";

        public event Action<IDialogResult> RequestClose;

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
