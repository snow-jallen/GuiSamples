using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager)
        {
            Title = "Prism Application";
            this.regionManager = regionManager;
        }

        private string title;
        private readonly IRegionManager regionManager;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
