using System.Windows;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// CirclePanel.xaml 的交互逻辑
    /// </summary>
    public partial class CirclePanel
    {
        public CirclePanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            HandyControl.Controls.CirclePanel panel = button.Parent as HandyControl.Controls.CirclePanel;
            int selIndex = panel.Children.IndexOf(button);
            HandyControl.Controls.MessageBox.Show("You choose button " + selIndex);
        }
    }
}
