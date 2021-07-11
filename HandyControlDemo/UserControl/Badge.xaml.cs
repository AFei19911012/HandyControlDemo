using System.Windows;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Badge.xaml 的交互逻辑
    /// </summary>
    public partial class Badge
    {
        public Badge()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is System.Windows.Controls.Button button))
            {
                return;
            }
            if (!(button.Parent is HandyControl.Controls.Badge badge))
            {
                return;
            }
            badge.Value += 1;
        }
    }
}
