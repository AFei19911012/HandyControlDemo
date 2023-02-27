using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControlDemo.UserControl.Window;
using System;

namespace HandyControlDemo.ViewModel
{
    public class NotifyIconViewModel : ViewModelBase
    {
        private bool isShowIcon;
        public bool IsShowIcon
        {
            get => isShowIcon;
            set => Set(ref isShowIcon, value);
        }

        private bool isBlink;
        public bool IsBlink
        {
            get => isBlink;
            set => Set(ref isBlink, value);
        }

        private string textInfo = "Hello~~";
        public string TextInfo
        {
            get => textInfo;
            set => Set(ref textInfo, value);
        }

        //public RelayCommand<object> MouseCmd => new Lazy<RelayCommand<object>>(() =>
        //    new RelayCommand<object>(str => Growl.Info(str.ToString(), "InfoMessage"))).Value;
        public RelayCommand MouseCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(ExecuteShowInfo)).Value;
        private void ExecuteShowInfo()
        {
            Growl.Info(TextInfo, "InfoMessage");
            IsBlink = false;
        }

        public RelayCommand CancleBlinkCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(ExecuteHiddenBlink)).Value;
        private void ExecuteHiddenBlink()
        {
            IsBlink = false;
        }

        public RelayCommand SendNotificationCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(SendNotification)).Value;
        private void SendNotification()
        {
            NotifyIcon.ShowBalloonTip("HandyControl", TextInfo, NotifyIconInfoType.Info, "NotifyIconToken");
        }

        public RelayCommand OpenCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Notification.Show(new AppNotification(TextInfo), ShowAnimation.None, true))).Value;
    }
}
