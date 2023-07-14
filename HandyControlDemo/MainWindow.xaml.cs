using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using HandyControlDemo.Model;
using HandyControlDemo.ViewModel;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace HandyControlDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        private MainWindowViewModel VM { get; set; }
        private int ThemeColorFlag { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();

            InitialResourceDictionary();

            VM = DataContext as MainWindowViewModel;

            Edit_Xaml.Load("../HandyControlDemo/MainWindow.xaml");
            Edit_XamlCs.Load("../HandyControlDemo/MainWindow.xaml.cs");
            Edit_VM.Load("../HandyControlDemo/ViewModel/MainWindowViewModel.cs");
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

        // Language
        private void UpdataLanguage()
        {
            int len = VM.DataList.Count;
            for (int i = 0; i < len; i++)
            {
                if (VM.DataList[i].Name == "Button" || VM.DataList[i].Name == "按钮")
                {
                    VM.DataList[i].Name = (string)FindResource("Button");
                }
                else if (VM.DataList[i].Name == "Brush" || VM.DataList[i].Name == "画刷")
                {
                    VM.DataList[i].Name = (string)FindResource("Brush");
                }
            }
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
            UpdataLanguage();
        }

        // Minimize
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Close
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (VM.SelectedIndex >= 0)
            {
                if (VM.DataList[VM.SelectedIndex].Name == "NotifyIcon")
                {
                    _ = HandyControl.Controls.MessageBox.Show(new MessageBoxInfo
                    {
                        Message = "Window will be hidden not closed.",
                        Caption = "Title",
                        Button = MessageBoxButton.OK,
                        IconBrushKey = ResourceToken.AccentBrush,
                        IconKey = ResourceToken.AskGeometry,
                        StyleKey = "MessageBoxCustom"
                    });
                    Hide();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        // Growl MenuItem
        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ContextMenu menu = (sender as StackPanel).ContextMenu;
            MenuItem item = menu.Items[0] as MenuItem;
            item.Header = Resources["Clear"];
        }

        // User Defined NotifyIcon
        private void ButtonNotifyIconTest_Click(object sender, RoutedEventArgs e)
        {
            NotifyIcon notify = new NotifyIcon
            {
                Icon = new BitmapImage(new Uri("pack://application:,,,/Resource/Image/Flag/cn.png")),
                //Token = "TokenTest",
                Visibility = Visibility.Visible,
            };
            _ = panle.Children.Add(notify);
            notify.Click += Notify_Click;
            NotifyIcon.ShowBalloonTip("HandyControl", "Test", NotifyIconInfoType.Info, "");
        }
        // User Defined NotifyIcon: Do Something
        private void Notify_Click(object sender, RoutedEventArgs e)
        {
            _ = HandyControl.Controls.MessageBox.Show("22");
        }

        // Search
        private void SearchBar_OnSearchStarted(object sender, FunctionEventArgs<string> e)
        {
            string key = e.Info;
            if (!(sender is FrameworkElement searchBar && searchBar.Tag is ListBox listBox))
            {
                return;
            }

            if (string.IsNullOrEmpty(key))
            {
                foreach (DemoDataModel item in listBox.Items)
                {
                    string name = item.Name.ToLower();
                    ListBoxItem listBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    listBoxItem?.Show(true);
                }
            }
            else
            {
                key = key.ToLower();
                foreach (DemoDataModel item in listBox.Items)
                {
                    string name = item.Name.ToLower();
                    ListBoxItem listBoxItem = listBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    if (name.Contains(key))
                    {
                        listBoxItem?.Show(true);
                    }
                    else
                    {
                        listBoxItem?.Show(false);
                    }

                }
            }
        }

        // Sort
        private void ButtonAscending_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button && button.Tag is ItemsControl itemsControl)
            {
                if (button.IsChecked == true)
                {
                    itemsControl.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                }
                else
                {
                    itemsControl.Items.SortDescriptions.Clear();
                }
            }
        }

        // UserControl Show
        private void ListBoxDemo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VM.SelectedIndex < 0)
            {
                return;
            };
            mainContent.Children.Clear();
            string name = (ListBoxDemo.SelectedItem as DemoDataModel).Name;

            if (Helper.AssemblyHelper.CreateInternalInstance($"UserControl.{name}") is System.Windows.Controls.UserControl ctrl)
            {
                mainContent.Children.Add(ctrl);

                Edit_Xaml.Load($"../HandyControlDemo/UserControl/{name}.xaml");
                Edit_XamlCs.Load($"../HandyControlDemo/UserControl/{name}.xaml.cs");

                string filename = $"../HandyControlDemo/ViewModel/{name}ViewModel.cs";
                if (File.Exists(filename))
                {
                    Edit_VM.Load(filename);
                }
            }
        }
    }
}
