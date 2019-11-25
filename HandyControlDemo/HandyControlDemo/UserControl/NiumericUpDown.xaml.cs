using HandyControl.Data;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// NiumericUpDown.xaml 的交互逻辑
    /// </summary>
    public partial class NiumericUpDown
    {
        public NiumericUpDown()
        {
            InitializeComponent();

            NumericUpDownCustomVerify.VerifyFunc = str => double.TryParse(str, out var v)
                ? v < 1e-06
                    ? OperationResult.Failed((string)FindResource("OutOfRange"))
                    : OperationResult.Success()
                : OperationResult.Failed((string)FindResource("Error"));
        }
    }
}
