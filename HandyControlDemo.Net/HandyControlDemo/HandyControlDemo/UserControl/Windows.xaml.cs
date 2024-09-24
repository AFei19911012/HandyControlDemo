using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using System.Windows;
using MessageBox = HandyControl.Controls.MessageBox;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Window.xaml 的交互逻辑
    /// </summary>
    public partial class Windows
    {
        public Windows()
        {
            InitializeComponent();
        }

        private void ButtonMessage_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("A new version has been detected! Do you want to updata?", "Title", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void ButtonCustomMessage_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(new MessageBoxInfo
            {
                Message = "A new version has been detected! Do you want to updata?",
                Caption = "Title",
                Button = MessageBoxButton.YesNo,
                IconBrushKey = ResourceToken.AccentBrush,
                IconKey = ResourceToken.AskGeometry,
                StyleKey = "MessageBoxCustom"
            });
        }

        private void ButtonCustomContent_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var picker = SingleOpenHelper.CreateControl<HandyControl.Controls.ColorPicker>();
            var window = new PopupWindow
            {
                PopupElement = picker,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                MinWidth = 0,
                MinHeight = 0,
                Title = "ColorPicker"
            };
            picker.SelectedColorChanged += delegate { window.Close(); };
            picker.Canceled += delegate { window.Close(); };
            window.Show();
        }

        private void ButtonMouseFollow_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var picker = SingleOpenHelper.CreateControl<HandyControl.Controls.ColorPicker>();
            var window = new PopupWindow
            {
                PopupElement = picker
            };
            picker.SelectedColorChanged += delegate { window.Close(); };
            picker.Canceled += delegate { window.Close(); };
            window.Show(ButtonMouseFollow, false);
        }
    }
}
