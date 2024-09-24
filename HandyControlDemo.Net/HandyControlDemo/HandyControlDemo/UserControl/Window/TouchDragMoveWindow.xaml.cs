using HandyControl.Tools;
using System.Windows.Input;

namespace HandyControlDemo.UserControl.Window
{
    /// <summary>
    /// TouchDragMoveWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TouchDragMoveWindow
    {
        private int _currentTouchCount;

        public TouchDragMoveWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_TouchUp(object sender, TouchEventArgs e)
        {
            _currentTouchCount--;
        }

        private void MainWindow_TouchDown(object sender, TouchEventArgs e)
        {
            CaptureTouch(e.TouchDevice);

            if (_currentTouchCount == 0) this.TouchDragMove();

            _currentTouchCount++;
        }
    }
}
