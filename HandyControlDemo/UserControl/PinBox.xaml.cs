using System.Windows;
using HandyControl.Controls;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// PinBox.xaml 的交互逻辑
    /// </summary>
    public partial class PinBox
    {
        public PinBox()
        {
            InitializeComponent();
        }

        private void PinBox_OnCompleted(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is HandyControl.Controls.PinBox pinBox)
            {
                HandyControl.Controls.Growl.Info(pinBox.Password);
            }
        }
    }
}
