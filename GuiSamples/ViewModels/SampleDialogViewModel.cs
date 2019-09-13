using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.Wpf.ViewModels
{
    public class SampleDialogViewModel : BindableBase
    {
        public SampleDialogViewModel()
        {

        }

        private string title = "Sample Dialog ViewModel";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
