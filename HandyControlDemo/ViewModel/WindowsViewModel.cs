using GalaSoft.MvvmLight.Command;
using HandyControlDemo.Helper;
using System;
using System.Windows;

namespace HandyControlDemo.ViewModel
{
    public class WindowsViewModel
    {
        public RelayCommand<string> OpenWindowCmd => new Lazy<RelayCommand<string>>(() => new RelayCommand<string>(OpenWindow)).Value;

        private void OpenWindow(string windowTag)
        {
            if (AssemblyHelper.CreateInternalInstance($"UserControl.Window.{windowTag}") is Window window)
            {
                window.Owner = Application.Current.MainWindow;
                window.ShowDialog();
            }
        }
    }
}
