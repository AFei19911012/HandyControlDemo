namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Magnifier.xaml 的交互逻辑
    /// </summary>
    public partial class Magnifier
    {
        public string ImgPath { get; set; }
        public Magnifier()
        {
            InitializeComponent();

            ImgPath = "pack://application:,,,/Resource/Image/1.jpg";

            DataContext = this;
        }
    }
}
