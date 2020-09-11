using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GuiSamples.Wpf
{
    public interface IClipboardService
    {
        string GetClipboardContent();
    }

    public class ClipboardService : IClipboardService
    {
        public string GetClipboardContent() => Clipboard.GetText();
    }
}
