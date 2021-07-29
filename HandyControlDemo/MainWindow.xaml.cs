using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using HandyControlDemo.Model;
using HandyControlDemo.ViewModel;
using System;
using System.ComponentModel;
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
        private MainWindowViewModel vm;
        private int ThemeColorFlag = 0;

        public MainWindow()
        {
            InitializeComponent();

            InitialResourceDictionary();
            vm = new MainWindowViewModel();

            DataContext = vm;
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
            int len = vm.DataList.Count;
            for (int i = 0; i < len; i++)
            {
                if (vm.DataList[i].Name == "Button" || vm.DataList[i].Name == "按钮")
                {
                    vm.DataList[i].Name = (string)FindResource("Button");
                }
                else if (vm.DataList[i].Name == "Brush" || vm.DataList[i].Name == "画刷")
                {
                    vm.DataList[i].Name = (string)FindResource("Brush");
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
            if (vm.SelectedIndex >= 0)
            {
                if (vm.DataList[vm.SelectedIndex].Name == "NotifyIcon")
                {
                    HandyControl.Controls.MessageBox.Show(new MessageBoxInfo
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
            panle.Children.Add(notify);
            notify.Click += Notify_Click;
            NotifyIcon.ShowBalloonTip("HandyControl", "Test", NotifyIconInfoType.Info, "");
        }
        // User Defined NotifyIcon: Do Something
        private void Notify_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("22");
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
            if (vm.SelectedIndex < 0)
            {
                return;
            };
            mainContent.Children.Clear();
            string name = (ListBoxDemo.SelectedItem as DemoDataModel).Name;
            if (name == "AnimationPath")
            {
                mainContent.Children.Add(new UserControl.AnimationPath());
            }
            else if (name == "Badge")
            {
                mainContent.Children.Add(new UserControl.Badge());
            }
            else if (name == "Border")
            {
                mainContent.Children.Add(new UserControl.Border());
            }
            else if (name == "Brush")
            {
                mainContent.Children.Add(new UserControl.Brush());
            }
            else if (name == "Button")
            {
                mainContent.Children.Add(new UserControl.Button());
            }
            else if (name == "Calendar")
            {
                mainContent.Children.Add(new UserControl.Calendar());
            }
            else if (name == "Card")
            {
                mainContent.Children.Add(new UserControl.Card());
            }
            else if (name == "Carousel")
            {
                mainContent.Children.Add(new UserControl.Carousel());
            }
            else if (name == "CirclePanel")
            {
                mainContent.Children.Add(new UserControl.CirclePanel());
            }
            else if (name == "ColorPicker")
            {
                mainContent.Children.Add(new UserControl.ColorPicker());
            }
            else if (name == "ComboBox")
            {
                mainContent.Children.Add(new UserControl.ComboBox());
            }
            else if (name == "CompareSlider")
            {
                mainContent.Children.Add(new UserControl.CompareSlider());
            }
            else if (name == "CoverFlow")
            {
                mainContent.Children.Add(new UserControl.CoverFlow());
            }
            else if (name == "CoverView")
            {
                mainContent.Children.Add(new UserControl.CoverView());
            }
            else if (name == "DataGrid")
            {
                mainContent.Children.Add(new UserControl.DataGrid());
            }
            else if (name == "DatePicker")
            {
                mainContent.Children.Add(new UserControl.DatePicker());
            }
            else if (name == "Dialog")
            {
                mainContent.Children.Add(new UserControl.Dialog());
            }
            else if (name == "Divider")
            {
                mainContent.Children.Add(new UserControl.Divider());
            }
            else if (name == "Drawer")
            {
                mainContent.Children.Add(new UserControl.Drawer());
            }
            else if (name == "Expander")
            {
                mainContent.Children.Add(new UserControl.Expander());
            }
            else if (name == "FloatingBlock")
            {
                mainContent.Children.Add(new UserControl.FloatingBlock());
            }
            else if (name == "FlowDocument")
            {
                mainContent.Children.Add(new UserControl.FlowDocument());
            }
            else if (name == "Geometry")
            {
                mainContent.Children.Add(new UserControl.Geometry());
            }
            else if (name == "GifImage")
            {
                mainContent.Children.Add(new UserControl.GifImage());
            }
            else if (name == "GotoTop")
            {
                mainContent.Children.Add(new UserControl.GotoTop());
            }
            else if (name == "Gravatar")
            {
                mainContent.Children.Add(new UserControl.Gravatar());
            }
            else if (name == "Grid")
            {
                mainContent.Children.Add(new UserControl.Grid());
            }
            else if (name == "GroupBox")
            {
                mainContent.Children.Add(new UserControl.GroupBox());
            }
            else if (name == "Growl")
            {
                mainContent.Children.Add(new UserControl.Growl());
            }
            else if (name == "HatchBrushGenerator")
            {
                mainContent.Children.Add(new UserControl.HatchBrushGenerator());
            }
            else if (name == "ImageBlock")
            {
                mainContent.Children.Add(new UserControl.ImageBlock());
            }
            else if (name == "ImageBrowser")
            {
                mainContent.Children.Add(new UserControl.ImageBrowser());
            }
            else if (name == "Label")
            {
                mainContent.Children.Add(new UserControl.Label());
            }
            else if (name == "ListBox")
            {
                mainContent.Children.Add(new UserControl.ListBox());
            }
            else if (name == "ListView")
            {
                mainContent.Children.Add(new UserControl.ListView());
            }
            else if (name == "Loading")
            {
                mainContent.Children.Add(new UserControl.Loading());
            }
            else if (name == "Magnifier")
            {
                mainContent.Children.Add(new UserControl.Magnifier());
            }
            else if (name == "Menu")
            {
                mainContent.Children.Add(new UserControl.Menu());
            }
            else if (name == "MorphingAnimation")
            {
                mainContent.Children.Add(new UserControl.MorphingAnimation());
            }
            else if (name == "NumericUpDown")
            {
                mainContent.Children.Add(new UserControl.NumericUpDown());
            }
            else if (name == "Notification")
            {
                mainContent.Children.Add(new UserControl.Notification());
            }
            else if (name == "NotifyIcon")
            {
                mainContent.Children.Add(new UserControl.NotifyIcon());
            }
            else if (name == "OutlineText")
            {
                mainContent.Children.Add(new UserControl.OutlineText());
            }
            else if (name == "PasswordBox")
            {
                mainContent.Children.Add(new UserControl.PasswordBox());
            }
            else if (name == "Poptip")
            {
                mainContent.Children.Add(new UserControl.Poptip());
            }
            else if (name == "PreviewSlider")
            {
                mainContent.Children.Add(new UserControl.PreviewSlider());
            }
            else if (name == "ProgressBar")
            {
                mainContent.Children.Add(new UserControl.ProgressBar());
            }
            else if (name == "RangeSlider")
            {
                mainContent.Children.Add(new UserControl.RangeSlider());
            }
            else if (name == "Rate")
            {
                mainContent.Children.Add(new UserControl.Rate());
            }
            else if (name == "RichTextBox")
            {
                mainContent.Children.Add(new UserControl.RichTextBox());
            }
            else if (name == "RunningBlock")
            {
                mainContent.Children.Add(new UserControl.RunningBlock());
            }
            else if (name == "ScrollViewer")
            {
                mainContent.Children.Add(new UserControl.ScrollViewer());
            }
            else if (name == "SearchBar")
            {
                mainContent.Children.Add(new UserControl.SearchBar());
            }
            else if (name == "Shield")
            {
                mainContent.Children.Add(new UserControl.Shield());
            }
            else if (name == "SideMenu")
            {
                mainContent.Children.Add(new UserControl.SideMenu());
            }
            else if (name == "Slider")
            {
                mainContent.Children.Add(new UserControl.Slider());
            }
            else if (name == "SplitButton")
            {
                mainContent.Children.Add(new UserControl.SplitButton());
            }
            else if (name == "Sprite")
            {
                mainContent.Children.Add(new UserControl.Sprite());
            }
            else if (name == "StepBar")
            {
                mainContent.Children.Add(new UserControl.StepBar());
            }
            else if (name == "TabControl")
            {
                mainContent.Children.Add(new UserControl.TabControl());
            }
            else if (name == "Tag")
            {
                mainContent.Children.Add(new UserControl.Tag());
            }
            else if (name == "TextBlock")
            {
                mainContent.Children.Add(new UserControl.TextBlock());
            }
            else if (name == "TextBox")
            {
                mainContent.Children.Add(new UserControl.TextBox());
            }
            else if (name == "TimeBar")
            {
                mainContent.Children.Add(new UserControl.TimeBar());
            }
            else if (name == "TimePicker")
            {
                mainContent.Children.Add(new UserControl.TimePicker());
            }
            else if (name == "ToolBar")
            {
                mainContent.Children.Add(new UserControl.ToolBar());
            }
            else if (name == "Transfer")
            {
                mainContent.Children.Add(new UserControl.Transfer());
            }
            else if (name == "TransitioningContentControl")
            {
                mainContent.Children.Add(new UserControl.TransitioningContentControl());
            }
            else if (name == "TreeView")
            {
                mainContent.Children.Add(new UserControl.TreeView());
            }
            else if (name == "WaterfallPanel")
            {
                mainContent.Children.Add(new UserControl.WaterfallPanel());
            }
            else if (name == "Windows")
            {
                mainContent.Children.Add(new UserControl.Windows());
            }          
            else if (name == "ChatBubble")
            {
                mainContent.Children.Add(new UserControl.ChatBubble());
            }
            else if (name == "FlipClock")
            {
                mainContent.Children.Add(new UserControl.FlipClock());
            }
            else if (name == "HoneycombPanel")
            {
                mainContent.Children.Add(new UserControl.HoneycombPanel());
            }
            else if (name == "Pagination")
            {
                mainContent.Children.Add(new UserControl.Pagination());
            }
            else if (name == "Screenshot")
            {
                mainContent.Children.Add(new UserControl.Screenshot());
            }
            else if (name == "Effects")
            {
                mainContent.Children.Add(new UserControl.Effects());
            }
            else if (name == "PropertyGrid")
            {
                mainContent.Children.Add(new UserControl.PropertyGrid());
            }
            else if (name == "ImageSelector")
            {
                mainContent.Children.Add(new UserControl.ImageSelector());
            }
            else if (name == "CheckComboBox")
            {
                mainContent.Children.Add(new UserControl.CheckComboBox());
            }
            else if (name == "PinBox")
            {
                mainContent.Children.Add(new UserControl.PinBox());
            }
            else if (name == "Clock")
            {
                mainContent.Children.Add(new UserControl.Clock());
            }
            else if (name == "CalendarWithClock")
            {
                mainContent.Children.Add(new UserControl.CalendarWithClock());
            }
            else if (name == "ElementGroup")
            {
                mainContent.Children.Add(new UserControl.ElementGroup());
            }
            else if (name == "FlexPanel")
            {
                mainContent.Children.Add(new UserControl.FlexPanel());
            }
            else if (name == "UniformSpacingPanel")
            {
                mainContent.Children.Add(new UserControl.UniformSpacingPanel());
            }
            else if (name == "RelativePanel")
            {
                mainContent.Children.Add(new UserControl.RelativePanel());
            }
        }
    }
}
