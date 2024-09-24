using HandyControl.Controls;
using HandyControlDemo.Helper;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Button.xaml 的交互逻辑
    /// </summary>
    public partial class Button
    {
        private int count = 0;
        public Button()
        {
            InitializeComponent();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            count += 1;
            if (!(sender is RepeatButton button))
            {
                return;
            }
            button.Content = "Repeat Button: " + count;
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is ProgressButton button))
            {
                return;
            }
            for (int i = 0; i < 1000; i++)
            {
                button.Progress = 0.1 * (i + 1);
                DispatcherHelper.DoEvents();
            }
        }
    }
}
