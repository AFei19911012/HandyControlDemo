using System.Windows;

namespace HandyControlDemo.UserControl.Window
{
    /// <summary>
    /// NoNonClientAreaDragableWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NoNonClientAreaDragableWindow
    {
        public NoNonClientAreaDragableWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
