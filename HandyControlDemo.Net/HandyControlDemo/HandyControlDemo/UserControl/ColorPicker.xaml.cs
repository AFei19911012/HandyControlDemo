using HandyControl.Controls;
using HandyControl.Data;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void ColorPicker_Canceled(object sender, System.EventArgs e)
        {
            MessageBox.Show("You click CancleButton.");
        }

        private void ColorPicker_SelectedColorChanged(object sender, FunctionEventArgs<System.Windows.Media.Color> e)
        {
            MessageBox.Show("You choose color: " + colorPicker.SelectedBrush.ToString());
        }
    }
}
