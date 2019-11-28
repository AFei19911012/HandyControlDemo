using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HandyControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private int ThemeColorFlag = 0;
        public MainWindow()
        {
            InitializeComponent();

            InitialResourceDictionary();
        }

        // Ititial ResourceDictionary
        private void InitialResourceDictionary()
        {
            // Theme
            ResourceDictionary theme = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resource/Style/Theme/BaseLight.xaml")
            };
            Resources.MergedDictionaries.Add(theme);
            // Color
            ResourceDictionary color = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resource/Style/Primary/Primary.xaml")
            };
            Resources.MergedDictionaries.Add(color);
            // Language
            ResourceDictionary lang = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Resource/Lang/Lang.zh-CN.xaml")
            };
            Resources.MergedDictionaries.Add(lang);
        }

        // Updata ResourceDictionary
        private void UpdataResourceDictionary(string resourceStr, int pos)
        {
            if (pos < 0 || pos > 2)
            {
                return;
            }
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri(resourceStr)
            };
            Resources.MergedDictionaries.RemoveAt(pos);
            Resources.MergedDictionaries.Insert(pos, resource);
        }  

        // Theme
        private void ButtonTheme_Click(object sender, RoutedEventArgs e)
        {
            //checkBox.SetResourceReference(BackgroundProperty, "AccentBrush");
            //Resources["PrimaryBrush"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5722"));
            //Resources["PrimaryBrush"] = (Brush)FindResource("BrushDanger");
            if (!(sender is Button button))
            {
                return;
            }
            string resourceStr = "pack://application:,,,/Resource/Style/Theme/BaseLight.xaml";
            if (button.Content.ToString() == "BaseDark")
            {
                resourceStr = "pack://application:,,,/Resource/Style/Theme/BaseDark.xaml";
            }
            UpdataResourceDictionary(resourceStr, 0);
        }

        // Primary Color
        private void ButtonColor_Click(object sender, RoutedEventArgs e)
        {
            ThemeColorFlag = (ThemeColorFlag + 1) % 3;
            string resourceStr = "pack://application:,,,/Resource/Style/Primary/Primary.xaml";
            if (ThemeColorFlag == 1)
            {
                resourceStr = "pack://application:,,,/Resource/Style/Primary/Magenta.xaml";
            }
            else if (ThemeColorFlag == 2)
            {
                resourceStr = "pack://application:,,,/Resource/Style/Primary/Violet.xaml";
            }
            UpdataResourceDictionary(resourceStr, 1);
        }

        // Language
        private void ButtonLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
            {
                return;
            }
            string resourceStr = "pack://application:,,,/Resource/Lang/Lang.en-US.xaml";
            if (button.Content.ToString() == "Cn")
            {
                resourceStr = "pack://application:,,,/Resource/Lang/Lang.zh-CN.xaml";
            }
            UpdataResourceDictionary(resourceStr, 2);
            if (button.Content.ToString() == "En")
            {
                ConfigHelper.Instance.SetLang("en");
            }
            else if (button.Content.ToString() == "Cn")
            {
                ConfigHelper.Instance.SetLang("zh-cn");
            }
        }

        // Minimize
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Close
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //Close();
            Hide();
        }

        // Growl MenuItem
        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContextMenu menu = (sender as StackPanel).ContextMenu;
            MenuItem item = menu.Items[0] as MenuItem;
            item.Header = Resources["Clear"];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NotifyIcon notify = new NotifyIcon
            {
                Token = "TokenTest",
                Visibility = Visibility.Visible,
            };
            panle.Children.Add(notify);
            notify.Click += Notify_Click;

            NotifyIcon.ShowBalloonTip("HandyControl", "Test", NotifyIconInfoType.Info, "TokenTest");
        }

        private void Notify_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("22");
        }
    }
}
