using HandyControl.Data;
using System.Windows;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// Growl.xaml 的交互逻辑
    /// </summary>
    public partial class Growl
    {
        public Growl()
        {
            InitializeComponent();
        }

        private void ButtonWindow_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is System.Windows.Controls.Button button))
            {
                return;
            }
            string content = button.Content.ToString();
            if (content == "Info")
            {
                HandyControl.Controls.Growl.Info("Info Message", "InfoMessage");
            }
            else if (content == "Success")
            {
                HandyControl.Controls.Growl.Success("Success Message", "InfoMessage");
            }
            else if (content == "Warning")
            {
                //Growl.Warning("Warning Message", "ErrorMessage");
                HandyControl.Controls.Growl.Warning(new GrowlInfo
                {
                    Message = "Warning Message",
                    CancelStr = "Ignore",
                    ConfirmStr = "确定",
                    ActionBeforeClose = isConfirmed =>
                    {
                        HandyControl.Controls.Growl.Info(isConfirmed.ToString(), "InfoMessage");
                        return true;
                    },
                    Token = "ErrorMessage",
                });
            }
            else if (content == "Error")
            {
                HandyControl.Controls.Growl.Error("Error Message", "ErrorMessage");
            }
            else if (content == "Ask")
            {
                //Growl.Ask("Ask Message", isConfirmed =>
                //{
                //    Growl.Info(isConfirmed.ToString(), "InfoMessage");
                //    // Command
                //    //HandyControl.Controls.MessageBox.Show(isConfirmed.ToString());
                //    return true;
                //}, "InfoMessage");
                HandyControl.Controls.Growl.Ask(new GrowlInfo
                {
                    Message = "Ask Message",
                    CancelStr = "No",
                    ConfirmStr = "是",
                    ActionBeforeClose = isConfirmed =>
                    {
                        HandyControl.Controls.Growl.Info(isConfirmed.ToString(), "InfoMessage");
                        return true;
                    },
                    Token = "InfoMessage",
                });
            }
            else if (content == "Fatal")
            {
                HandyControl.Controls.Growl.Fatal("Fatal Message", "ErrorMessage");
            }
            else if (content == "Clear")
            {
                HandyControl.Controls.Growl.Clear("InfoMessage");
            }
        }

        private void ButtonDesktop_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is System.Windows.Controls.Button button))
            {
                return;
            }
            string content = button.Content.ToString();
            if (content == "Info")
            {
                HandyControl.Controls.Growl.InfoGlobal("Info Message");
            }
            else if (content == "Success")
            {
                HandyControl.Controls.Growl.SuccessGlobal("Success Message");
            }
            else if (content == "Warning")
            {
                HandyControl.Controls.Growl.WarningGlobal("Warning Message");
            }
            else if (content == "Error")
            {
                HandyControl.Controls.Growl.ErrorGlobal("Error Message");
            }
            else if (content == "Ask")
            {
                HandyControl.Controls.Growl.AskGlobal("Ask Message", isConfirmed =>
                {
                    HandyControl.Controls.Growl.Info(isConfirmed.ToString(), "InfoMessage");
                    return true;
                });
            }
            else if (content == "Fatal")
            {
                HandyControl.Controls.Growl.FatalGlobal("Fatal Message");
            }
            else if (content == "Clear")
            {
                HandyControl.Controls.Growl.ClearGlobal();
            }
        }
    }
}
