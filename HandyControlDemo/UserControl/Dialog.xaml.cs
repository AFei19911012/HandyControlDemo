using HandyControlDemo.Helper;
using HandyControlDemo.UserControl.Window;
using HandyControlDemo.ViewModel;
using System.Windows;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog
    {
        public static DialogViewModel vm;
        public Dialog()
        {
            InitializeComponent();

            vm = new DialogViewModel
            {
                Content = ""
            };

            DataContext = vm;
        }

        private void TextDialog_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.Dialog.Show(new TextDialog("This is the content."));
        }

        private void MessageBox_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("This is MessageBox.");
        }

        private void TextDialogWithTimer_Click(object sender, RoutedEventArgs e)
        {
            TextDialogWithTimer dialog = new TextDialogWithTimer();
            HandyControl.Controls.Dialog.Show(dialog);
            // Customized
            int count = 200;
            int totalCount = 100 * count;
            for (int i = 1; i <= totalCount; i++)
            {
                dialog.vm.CurrentValue = i / count;
                dialog.vm.ShowText = "Current value: " + dialog.vm.CurrentValue;
                if (dialog.vm.CurrentValue == 100)
                {
                    dialog.vm.ShowText = "Finished";
                }
                if (dialog.IsPaused)
                {
                    HandyControl.Controls.MessageBox.Show("TextDialogWithTimer is paused.\n" +
                        "Current value is" + dialog.vm.CurrentValue);
                    break;
                }
                DispatcherHelper.DoEvents();
            }
        }

        //private async Task ShowInteractiveDialog(bool withTimer)
        //{
        //    if (!withTimer)
        //    {
        //        DialogResult = await Dialog.Show<InteractiveDialog>()
        //            .Initialize<InteractiveDialogViewModel>(vm => vm.Message = DialogResult)
        //            .GetResultAsync<string>();
        //    }
        //    else
        //    {
        //        await Dialog.Show<TextDialogWithTimer>(MessageToken.MainWindow).GetResultAsync<string>();
        //    }
        //}

        private void InteractiveDialog_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.Dialog.Show(new InteractiveDialog(vm.Content));
        }
    }
}
