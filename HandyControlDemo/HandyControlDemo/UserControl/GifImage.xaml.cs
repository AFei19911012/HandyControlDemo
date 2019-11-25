namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// GifImage.xaml 的交互逻辑
    /// </summary>
    public partial class GifImage
    {
        public string ImgPath1 { get; set; }
        public string ImgPath2 { get; set; }
        public string ImgPath3 { get; set; }
        public string ImgPath4 { get; set; }
        public string ImgPath5 { get; set; }
        public string ImgPath6 { get; set; }
        public string ImgPath7 { get; set; }
        public string ImgPath8 { get; set; }
        public string ImgPath9 { get; set; }
        public string ImgPath10 { get; set; }
        public GifImage()
        {
            InitializeComponent();

            ImgPath1 = "pack://application:,,,/Resource/Image/QQ/1.gif";
            ImgPath2 = "pack://application:,,,/Resource/Image/QQ/2.gif";
            ImgPath3 = "pack://application:,,,/Resource/Image/QQ/3.gif";
            ImgPath4 = "pack://application:,,,/Resource/Image/QQ/4.gif";
            ImgPath5 = "pack://application:,,,/Resource/Image/QQ/5.gif";
            ImgPath6 = "pack://application:,,,/Resource/Image/QQ/6.gif";
            ImgPath7 = "pack://application:,,,/Resource/Image/QQ/7.gif";
            ImgPath8 = "pack://application:,,,/Resource/Image/QQ/8.gif";
            ImgPath9 = "pack://application:,,,/Resource/Image/QQ/9.gif";
            ImgPath10 = "pack://application:,,,/Resource/Image/QQ/10.gif";

            DataContext = this;
        }
    }
}
