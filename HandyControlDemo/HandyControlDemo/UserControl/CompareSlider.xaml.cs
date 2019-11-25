namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// CompareSlider.xaml 的交互逻辑
    /// </summary>
    public partial class CompareSlider
    {
        public string ImgSource { get; set; }
        public string ImgTarget { get; set; }
        public CompareSlider()
        {
            InitializeComponent();

            ImgSource = "pack://application:,,,/Resource/Image/b2.jpg";
            ImgTarget = "pack://application:,,,/Resource/Image/b1.jpg";

            DataContext = this;
        }
    }
}
