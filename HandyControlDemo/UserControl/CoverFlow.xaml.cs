namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// CoverFlow.xaml 的交互逻辑
    /// </summary>
    public partial class CoverFlow
    {
        public CoverFlow()
        {
            InitializeComponent();

            // Load images
            for (int i = 1; i <= 5; i++)
            {
                CoverFlowMain.Add("pack://application:,,,/Resource/Image/" + i + ".jpg");
            }
        }
    }
}
