using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GuiSamples.Wpf.ViewModels
{
    public class SampleDialogViewModel : BindableBase, IDialogAware
    {
        public SampleDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(() =>
            {
                var closeParameters = new DialogParameters();
                closeParameters.Add("userEntry1", "blah");
                var result = new DialogResult(ButtonResult.OK, closeParameters);
                RequestClose?.Invoke(result);
            });
        }

        public DelegateCommand CloseDialogCommand { get; }

        private DelegateCommand doTheThing;
        public DelegateCommand DoTheThing => doTheThing ?? (doTheThing = new DelegateCommand(() => Title = "I did it at " + DateTime.Now.ToString()));

        private DelegateCommand doAnotherThing = new DelegateCommand(() => { });
        public DelegateCommand DoAnotherThing => doAnotherThing;

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

        private string clipboardText;
        public string ClipboardText
        {
            get => clipboardText;
            set { SetProperty(ref clipboardText, value); }
        }

        private DelegateCommand dumpClipboard;
        public DelegateCommand DumpClipboard => dumpClipboard ??= new DelegateCommand(() =>
        {
            ClipboardText = Clipboard.GetText();
        });

        private DelegateCommand copyToClipboard;
        public DelegateCommand CopyToClipboard => copyToClipboard ??= new DelegateCommand(() =>
        {
            Clipboard.SetText(ClipboardText);
        });
    }
}
