namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// ImageBlock.xaml 的交互逻辑
    /// </summary>
    public partial class ImageBlock
    {
        public string ImgPath { get; set; }
        public ImageBlock()
        {
            InitializeComponent();

            ImgPath = "pack://application:,,,/Resource/Image/Dance.png";

            DataContext = this;
        }
    }
}
