using System;
using System.Windows;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// ImageBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class ImageBrowser
    {
        public string ImgPath { get; set; }
        public ImageBrowser()
        {
            InitializeComponent();

            ImgPath = "pack://application:,,,/Resource/Image/1.jpg";

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HandyControl.Controls.ImageBrowser(new Uri(ImgPath)).Show();
        }
    }
}
