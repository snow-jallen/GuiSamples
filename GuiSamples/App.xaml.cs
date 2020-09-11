using CommonServiceLocator;
using GuiSamples.Views;
using GuiSamples.Wpf;
using GuiSamples.Wpf.ViewModels;
using GuiSamples.Wpf.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GuiSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MessagingView>();
            containerRegistry.RegisterForNavigation<ValidatingFormView>();
            containerRegistry.RegisterDialog<SampleDialogView, SampleDialogViewModel>(nameof(SampleDialogViewModel));
            containerRegistry.RegisterDialog<ClipboardManagerView, ClipboardManagerViewModel>(nameof(ClipboardManagerViewModel));

            containerRegistry.Register<IClipboardService, ClipboardService>();
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
