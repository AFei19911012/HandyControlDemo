namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// GifImage.xaml 的交互逻辑
    /// </summary>
    public partial class GifImage
    {
        public GifImage()
        {
            InitializeComponent();

            //gif.Uri = new System.Uri("pack://siteoforigin:,,,/D:/MyPrograms/Module/progress.gif");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gif.Uri = new System.Uri("pack://siteoforigin:,,,/D:/MyPrograms/Module/progress.gif");
        }
    }
}
