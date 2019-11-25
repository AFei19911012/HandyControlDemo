namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Gravatar.xaml 的交互逻辑
    /// </summary>
    public partial class Gravatar
    {
        public string ImgPath { get; set; }
        public Gravatar()
        {
            InitializeComponent();

            ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar1.png";

            DataContext = this;
        }
    }
}
