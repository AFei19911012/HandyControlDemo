using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HandyControlDemo.UserControl
{
    /// <summary>
    /// TabControl.xaml 的交互逻辑
    /// </summary>
    public partial class TabControl
    {
        private List<HandyControl.Controls.TabItem> DeleteTabItems = new List<HandyControl.Controls.TabItem>();
        public TabControl()
        {
            InitializeComponent();
        }

        // Resume Closed TabItem
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int itemCount = DeleteTabItems.Count;
            if (itemCount < 1)
            {
                return;
            }
            tabControl.Items.Add(DeleteTabItems[0]);
            DeleteTabItems.RemoveAt(0);
        }

        // Record Closed TabItem
        private void TabItem_Closed(object sender, EventArgs e)
        {
            HandyControl.Controls.TabItem item = sender as HandyControl.Controls.TabItem;
            DeleteTabItems.Insert(0, item);
            HandyControl.Controls.Growl.Info($"{(sender as TabItem)?.Header} Closed");
        }

        // Edit TabItem ContextMenu
        private void TabControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            int count = tabControl.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (!(tabControl.Items[i] is HandyControl.Controls.TabItem tabItem))
                {
                    continue;
                }
                DependencyObject d1 = VisualTreeHelper.GetChild(tabItem, 0);
                Grid grid = LogicalTreeHelper.FindLogicalNode(d1, "templateRoot") as Grid;
                ContextMenu menu = grid.ContextMenu;
                //menu.Visibility = Visibility.Hidden;
                (menu.Items[0] as MenuItem).Header = Resources["Close"];
                (menu.Items[1] as MenuItem).Header = Resources["CloseAll"];
                (menu.Items[2] as MenuItem).Header = Resources["CloseOther"];
                //(menu.Items[0] as MenuItem).Header = (string)Application.Current.Resources["Close"];
                //(menu.Items[1] as MenuItem).Header = (string)Application.Current.Resources["CloseAll"];
                //(menu.Items[2] as MenuItem).Header = (string)Application.Current.Resources["CloseOther"];
            }
        }
    }
}
