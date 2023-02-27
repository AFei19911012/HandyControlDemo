using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using System;

namespace HandyControlDemo.ViewModel
{
    public class SearchBarViewModel : ViewModelBase
    {
        public RelayCommand<string> SearchCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(Search)).Value;

        private void Search(string key)
        {
            Growl.Info(key, "InfoMessage");
        }
    }
}
