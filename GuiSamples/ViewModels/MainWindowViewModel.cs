using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Greeting => "Hello world!";
    }
}
