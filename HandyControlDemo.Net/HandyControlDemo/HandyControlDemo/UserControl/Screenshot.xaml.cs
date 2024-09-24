using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HandyControl.Controls;
using HandyControl.Data;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Screenshot.xaml 的交互逻辑
    /// </summary>
    public partial class Screenshot : IDisposable
    {
        public Screenshot()
        {
            InitializeComponent();
            HandyControl.Controls.Screenshot.Snapped += Screenshot_Snapped;
        }
        private void Screenshot_Snapped(object sender, FunctionEventArgs<ImageSource> e)
        {
            new HandyControl.Controls.Window
            {
                Content = new Image
                {
                    Source = e.Info,
                    Stretch = Stretch.None
                },
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            }.ShowDialog();
        }

        public void Dispose() => HandyControl.Controls.Screenshot.Snapped -= Screenshot_Snapped;
    }
}