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
        private MainWindowViewModel VM { get; set; }
        private int ThemeColorFlag { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();

            InitialResourceDictionary();

            VM = DataContext as MainWindowViewModel;
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
            if (name == "AnimationPath")
            {
                _ = mainContent.Children.Add(new UserControl.AnimationPath());
            }
            else if (name == "Badge")
            {
                _ = mainContent.Children.Add(new UserControl.Badge());
            }
            else if (name == "Border")
            {
                _ = mainContent.Children.Add(new UserControl.Border());
            }
            else if (name == "Brush")
            {
                _ = mainContent.Children.Add(new UserControl.Brush());
            }
            else if (name == "Button")
            {
                _ = mainContent.Children.Add(new UserControl.Button());
            }
            else if (name == "Calendar")
            {
                _ = mainContent.Children.Add(new UserControl.Calendar());
            }
            else if (name == "Card")
            {
                _ = mainContent.Children.Add(new UserControl.Card());
            }
            else if (name == "Carousel")
            {
                _ = mainContent.Children.Add(new UserControl.Carousel());
            }
            else if (name == "CirclePanel")
            {
                _ = mainContent.Children.Add(new UserControl.CirclePanel());
            }
            else if (name == "ColorPicker")
            {
                _ = mainContent.Children.Add(new UserControl.ColorPicker());
            }
            else if (name == "ComboBox")
            {
                _ = mainContent.Children.Add(new UserControl.ComboBox());
            }
            else if (name == "CompareSlider")
            {
                _ = mainContent.Children.Add(new UserControl.CompareSlider());
            }
            else if (name == "CoverFlow")
            {
                _ = mainContent.Children.Add(new UserControl.CoverFlow());
            }
            else if (name == "CoverView")
            {
                _ = mainContent.Children.Add(new UserControl.CoverView());
            }
            else if (name == "DataGrid")
            {
                _ = mainContent.Children.Add(new UserControl.DataGrid());
            }
            else if (name == "DatePicker")
            {
                _ = mainContent.Children.Add(new UserControl.DatePicker());
            }
            else if (name == "Dialog")
            {
                _ = mainContent.Children.Add(new UserControl.Dialog());
            }
            else if (name == "Divider")
            {
                _ = mainContent.Children.Add(new UserControl.Divider());
            }
            else if (name == "Drawer")
            {
                _ = mainContent.Children.Add(new UserControl.Drawer());
            }
            else if (name == "Expander")
            {
                _ = mainContent.Children.Add(new UserControl.Expander());
            }
            else if (name == "FloatingBlock")
            {
                _ = mainContent.Children.Add(new UserControl.FloatingBlock());
            }
            else if (name == "FlowDocument")
            {
                _ = mainContent.Children.Add(new UserControl.FlowDocument());
            }
            else if (name == "Geometry")
            {
                _ = mainContent.Children.Add(new UserControl.Geometry());
            }
            else if (name == "GifImage")
            {
                _ = mainContent.Children.Add(new UserControl.GifImage());
            }
            else if (name == "GotoTop")
            {
                _ = mainContent.Children.Add(new UserControl.GotoTop());
            }
            else if (name == "Gravatar")
            {
                _ = mainContent.Children.Add(new UserControl.Gravatar());
            }
            else if (name == "Grid")
            {
                _ = mainContent.Children.Add(new UserControl.Grid());
            }
            else if (name == "GroupBox")
            {
                _ = mainContent.Children.Add(new UserControl.GroupBox());
            }
            else if (name == "Growl")
            {
                _ = mainContent.Children.Add(new UserControl.Growl());
            }
            else if (name == "HatchBrushGenerator")
            {
                _ = mainContent.Children.Add(new UserControl.HatchBrushGenerator());
            }
            else if (name == "ImageBlock")
            {
                _ = mainContent.Children.Add(new UserControl.ImageBlock());
            }
            else if (name == "ImageBrowser")
            {
                _ = mainContent.Children.Add(new UserControl.ImageBrowser());
            }
            else if (name == "Label")
            {
                _ = mainContent.Children.Add(new UserControl.Label());
            }
            else if (name == "ListBox")
            {
                _ = mainContent.Children.Add(new UserControl.ListBox());
            }
            else if (name == "ListView")
            {
                _ = mainContent.Children.Add(new UserControl.ListView());
            }
            else if (name == "Loading")
            {
                _ = mainContent.Children.Add(new UserControl.Loading());
            }
            else if (name == "Magnifier")
            {
                _ = mainContent.Children.Add(new UserControl.Magnifier());
            }
            else if (name == "Menu")
            {
                _ = mainContent.Children.Add(new UserControl.Menu());
            }
            else if (name == "MorphingAnimation")
            {
                _ = mainContent.Children.Add(new UserControl.MorphingAnimation());
            }
            else if (name == "NumericUpDown")
            {
                _ = mainContent.Children.Add(new UserControl.NumericUpDown());
            }
            else if (name == "Notification")
            {
                _ = mainContent.Children.Add(new UserControl.Notification());
            }
            else if (name == "NotifyIcon")
            {
                _ = mainContent.Children.Add(new UserControl.NotifyIcon());
            }
            else if (name == "OutlineText")
            {
                _ = mainContent.Children.Add(new UserControl.OutlineText());
            }
            else if (name == "PasswordBox")
            {
                _ = mainContent.Children.Add(new UserControl.PasswordBox());
            }
            else if (name == "Poptip")
            {
                _ = mainContent.Children.Add(new UserControl.Poptip());
            }
            else if (name == "PreviewSlider")
            {
                _ = mainContent.Children.Add(new UserControl.PreviewSlider());
            }
            else if (name == "ProgressBar")
            {
                _ = mainContent.Children.Add(new UserControl.ProgressBar());
            }
            else if (name == "RangeSlider")
            {
                _ = mainContent.Children.Add(new UserControl.RangeSlider());
            }
            else if (name == "Rate")
            {
                _ = mainContent.Children.Add(new UserControl.Rate());
            }
            else if (name == "RichTextBox")
            {
                _ = mainContent.Children.Add(new UserControl.RichTextBox());
            }
            else if (name == "RunningBlock")
            {
                _ = mainContent.Children.Add(new UserControl.RunningBlock());
            }
            else if (name == "ScrollViewer")
            {
                _ = mainContent.Children.Add(new UserControl.ScrollViewer());
            }
            else if (name == "SearchBar")
            {
                _ = mainContent.Children.Add(new UserControl.SearchBar());
            }
            else if (name == "Shield")
            {
                _ = mainContent.Children.Add(new UserControl.Shield());
            }
            else if (name == "SideMenu")
            {
                _ = mainContent.Children.Add(new UserControl.SideMenu());
            }
            else if (name == "Slider")
            {
                _ = mainContent.Children.Add(new UserControl.Slider());
            }
            else if (name == "SplitButton")
            {
                _ = mainContent.Children.Add(new UserControl.SplitButton());
            }
            else if (name == "Sprite")
            {
                _ = mainContent.Children.Add(new UserControl.Sprite());
            }
            else if (name == "StepBar")
            {
                _ = mainContent.Children.Add(new UserControl.StepBar());
            }
            else if (name == "TabControl")
            {
                _ = mainContent.Children.Add(new UserControl.TabControl());
            }
            else if (name == "Tag")
            {
                _ = mainContent.Children.Add(new UserControl.Tag());
            }
            else if (name == "TextBlock")
            {
                _ = mainContent.Children.Add(new UserControl.TextBlock());
            }
            else if (name == "TextBox")
            {
                _ = mainContent.Children.Add(new UserControl.TextBox());
            }
            else if (name == "TimeBar")
            {
                _ = mainContent.Children.Add(new UserControl.TimeBar());
            }
            else if (name == "TimePicker")
            {
                _ = mainContent.Children.Add(new UserControl.TimePicker());
            }
            else if (name == "ToolBar")
            {
                _ = mainContent.Children.Add(new UserControl.ToolBar());
            }
            else if (name == "Transfer")
            {
                _ = mainContent.Children.Add(new UserControl.Transfer());
            }
            else if (name == "TransitioningContentControl")
            {
                _ = mainContent.Children.Add(new UserControl.TransitioningContentControl());
            }
            else if (name == "TreeView")
            {
                _ = mainContent.Children.Add(new UserControl.TreeView());
            }
            else if (name == "WaterfallPanel")
            {
                _ = mainContent.Children.Add(new UserControl.WaterfallPanel());
            }
            else if (name == "Windows")
            {
                _ = mainContent.Children.Add(new UserControl.Windows());
            }          
            else if (name == "ChatBubble")
            {
                _ = mainContent.Children.Add(new UserControl.ChatBubble());
            }
            else if (name == "FlipClock")
            {
                _ = mainContent.Children.Add(new UserControl.FlipClock());
            }
            else if (name == "HoneycombPanel")
            {
                _ = mainContent.Children.Add(new UserControl.HoneycombPanel());
            }
            else if (name == "Pagination")
            {
                _ = mainContent.Children.Add(new UserControl.Pagination());
            }
            else if (name == "Screenshot")
            {
                _ = mainContent.Children.Add(new UserControl.Screenshot());
            }
            else if (name == "Effects")
            {
                _ = mainContent.Children.Add(new UserControl.Effects());
            }
            else if (name == "PropertyGrid")
            {
                _ = mainContent.Children.Add(new UserControl.PropertyGrid());
            }
            else if (name == "ImageSelector")
            {
                _ = mainContent.Children.Add(new UserControl.ImageSelector());
            }
            else if (name == "CheckComboBox")
            {
                _ = mainContent.Children.Add(new UserControl.CheckComboBox());
            }
            else if (name == "PinBox")
            {
                _ = mainContent.Children.Add(new UserControl.PinBox());
            }
            else if (name == "Clock")
            {
                _ = mainContent.Children.Add(new UserControl.Clock());
            }
            else if (name == "CalendarWithClock")
            {
                _ = mainContent.Children.Add(new UserControl.CalendarWithClock());
            }
            else if (name == "ElementGroup")
            {
                _ = mainContent.Children.Add(new UserControl.ElementGroup());
            }
            else if (name == "FlexPanel")
            {
                _ = mainContent.Children.Add(new UserControl.FlexPanel());
            }
            else if (name == "UniformSpacingPanel")
            {
                _ = mainContent.Children.Add(new UserControl.UniformSpacingPanel());
            }
            else if (name == "RelativePanel")
            {
                _ = mainContent.Children.Add(new UserControl.RelativePanel());
            }
            else if (name == "Watermark")
            {
                _ = mainContent.Children.Add(new UserControl.WatermarkDemo());
            }
            else if (name == "AutoCompleteTextBox")
            {
                _ = mainContent.Children.Add(new UserControl.AutoCompleteTextBoxDemo());
            }
        }
    }
}