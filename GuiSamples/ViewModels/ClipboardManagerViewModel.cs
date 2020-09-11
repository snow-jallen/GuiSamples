using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Windows;

namespace GuiSamples.Wpf.ViewModels
{
    public class ClipboardManagerViewModel : BindableBase, IDialogAware
    {
        public ClipboardManagerViewModel(IClipboardService clipboardService)
        {
            this.clipboardService = clipboardService ?? throw new ArgumentNullException(nameof(clipboardService));
        }
        private string clipboardContents;
        public string ClipboardContents { get => clipboardContents; set => SetProperty(ref clipboardContents, value); }

        private DelegateCommand getClipboard;
        public DelegateCommand GetClipboard => getClipboard ??= new DelegateCommand(() =>
        {
            ClipboardContents = clipboardService.GetClipboardContent();
        });

        private DelegateCommand ok;
        public DelegateCommand OK => ok ??= new DelegateCommand(() =>
        {
            var resultParameters = new DialogParameters();
            resultParameters.Add("item", ClipboardContents);
            var result = new DialogResult(ButtonResult.OK, resultParameters);
            RequestClose?.Invoke(result);
        });

        private DelegateCommand cancel;
        private readonly IClipboardService clipboardService;

        public DelegateCommand Cancel => cancel ??= new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
        });

        public event Action<IDialogResult> RequestClose;

        public string Title => "Clipboard Manager";

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
