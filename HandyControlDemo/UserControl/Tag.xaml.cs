using HandyControl.Controls;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Tag.xaml 的交互逻辑
    /// </summary>
    public partial class Tag
    {
        public Tag()
        {
            InitializeComponent();
        }

        private void TagPanel_OnAddTagButtonClick(object sender, System.EventArgs e)
        {
            if (sender is TagPanel panel)
            {
                panel.Children.Add(new HandyControl.Controls.Tag
                {
                    Content = "SubTitle"
                });
            }
        }
    }
}
