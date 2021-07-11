using HandyControl.Data;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// PasswordBox.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordBox
    {
        public PasswordBox()
        {
            InitializeComponent();

            passwordBox.VerifyFunc = str => string.IsNullOrEmpty(str)
                ? OperationResult.Failed((string)FindResource("IsNecessary"))
                : OperationResult.Success();
        }
    }
}
