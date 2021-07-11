using HandyControl.Tools;
using HandyControlDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyControlDemo.UserControl.Window
{
    /// <summary>
    /// TextDialogWithTimer.xaml 的交互逻辑
    /// </summary>
    public partial class TextDialogWithTimer
    {
        public TextDialogWithTimerViewModel vm;
        public bool IsPaused = false;
        public TextDialogWithTimer()
        {
            InitializeComponent();

            //var animation = AnimationHelper.CreateAnimation(100, 2000);
            //animation.EasingFunction = null;
            //animation.Completed += Animation_Completed;
            //ProgressBarTimer.BeginAnimation(RangeBase.ValueProperty, animation);

            IsPaused = false;

            vm = new TextDialogWithTimerViewModel
            {
                ShowText = "Please wait...",
                CurrentValue = 0,
            };

            DataContext = vm;
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            vm.ShowText = "Finished";
            //ButtonClose.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            ButtonClose.Command.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsPaused = true;
        }
    }
}
