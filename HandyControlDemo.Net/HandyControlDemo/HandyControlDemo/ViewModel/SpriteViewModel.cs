using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControlDemo.UserControl.Window;
using System;

namespace HandyControlDemo.ViewModel
{
    public class SpriteViewModel
    {
        public RelayCommand OpenCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => Sprite.Show(new AppSprite()))).Value;
    }
}
