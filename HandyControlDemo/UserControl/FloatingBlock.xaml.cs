namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// FloatingBlock.xaml 的交互逻辑
    /// </summary>
    public partial class FloatingBlock
    {
        private int count = 0;
        public FloatingBlock()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            count += 1;
            (sender as System.Windows.Controls.Button).Content = "Click: " + count;
        }
    }
}
