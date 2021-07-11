using HandyControl.Controls;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Transfer.xaml 的交互逻辑
    /// </summary>
    public partial class Transfer
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("You choose " + transfer.SelectedItems.Count + " items.");
        }
    }
}
