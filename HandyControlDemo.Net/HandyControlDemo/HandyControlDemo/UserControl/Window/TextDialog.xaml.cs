namespace HandyControlDemo.UserControl.Window
{
    /// <summary>
    /// TextDialog.xaml 的交互逻辑
    /// </summary>
    public partial class TextDialog
    {
        public TextDialog(string info = "Please Wait...")
        {
            InitializeComponent();

            textBlock.Text = info;
        }
    }
}
