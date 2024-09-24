using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        private int selectedIndex;
        public int SelectedIndex    
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }

        public MainWindowViewModel()
        {
            SelectedIndex = -1;
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            //string name = Properties.Lang.ResourceManager.GetString("Button");
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Brush_16x.png", Name = "Brush"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ButtonClick_16x.png", Name = "Button"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ImageStack_16x.png", Name = "ImageBlock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ImageBrowser_16x.png", Name = "ImageBrowser"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DotLarge_16x.png", Name = "Badge"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/BorderElement_16x.png", Name = "Border"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/VSO_Card_16x.png", Name = "Card"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Carousel_16x.png", Name = "Carousel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ColorWheel_16x.png", Name = "CirclePanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ColorPalette_16x.png", Name = "ColorPicker"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ComboBox_16x.png", Name = "ComboBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/SplitterControl_16x.png", Name = "CompareSlider"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/LinearCarousel_16x.png", Name = "CoverFlow"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DetailDataView_16x.png", Name = "CoverView"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DataGrid_16x.png", Name = "DataGrid"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DatePicker_16x.png", Name = "DatePicker"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Dialog_16x.png", Name = "Dialog"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DottedSplitter_16x.png", Name = "Divider"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/View_Portrait_16x.png", Name = "Drawer"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Expander_16x.png", Name = "Expander"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/thumbs_up.png", Name = "FloatingBlock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Animation_16x.png", Name = "GifImage"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/GoToTop_16x.png", Name = "GotoTop"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/User_16x.png", Name = "Gravatar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/GridPane_16x.png", Name = "Grid"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/GroupBox_16x.png", Name = "GroupBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Message_16x.png", Name = "Growl"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Path_16x.png", Name = "AnimationPath"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/DataGenerator_16x.png", Name = "HatchBrushGenerator"},              
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ListBox_16x.png", Name = "ListBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ListView_16x.png", Name = "ListView"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Loading_Blue_16x.png", Name = "Loading"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Search_16x.png", Name = "Magnifier"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ContextMenu_16x.png", Name = "Menu"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Animation_16x.png", Name = "MorphingAnimation"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/NumericListBox_16x.png", Name = "NumericUpDown"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Procedure_16x.png", Name = "Notification"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/NotificationHub_16x.png", Name = "NotifyIcon"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TextBlock_16x.png", Name = "OutlineText"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/PasswordBox_16x.png", Name = "PasswordBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/HoverMenu_16x.png", Name = "Poptip"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Slider_16x.png", Name = "PreviewSlider"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ProgressBar_16x.png", Name = "ProgressBar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/brackets_Square_16xLG.png", Name = "RangeSlider"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Star.png", Name = "Rate"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/RichTextBox_16x.png", Name = "RichTextBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Dynamic_16x.png", Name = "RunningBlock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Search_16x.png", Name = "SearchBar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Shield_16x.png", Name = "Shield"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/MainMenuControl_16x.png", Name = "SideMenu"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Slider_16x.png", Name = "Slider"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/SplitButton_16x.png", Name = "SplitButton"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/HandyControl.png", Name = "Sprite"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Flow_16x.png", Name = "StepBar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TabPage_16x.png", Name = "TabControl"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Tag_16x.png", Name = "Tag"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TextBlock_16x.png", Name = "TextBlock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TextBox_16x.png", Name                                                                                    = "TextBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Timeline_16x.png", Name = "TimeBar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TimePicker_16x.png", Name = "TimePicker"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ToolBar_16x.png", Name = "ToolBar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Transfer_16x.png", Name = "Transfer"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TransitioningContentControl_16x.png", Name = "TransitioningContentControl"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TreeView_16x.png", Name = "TreeView"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Panel_16x.png", Name = "WaterfallPanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/WindowsForm_16x.png", Name = "Windows"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Bubble_16xLG.png", Name = "ChatBubble"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/FlipVertical_16x.png", Name = "FlipClock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/PolygonHexagon_16x.png", Name = "HoneycombPanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Paginator_16x.png", Name = "Pagination"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ScrollBox_16x.png", Name = "ScrollViewer"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Calendar_16x.png", Name = "Calendar"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/WPFFlowDocument_16x.png", Name = "FlowDocument"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Label_16x.png", Name = "Label"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Path_16x.png", Name = "Geometry"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/WindowScreenshot_16x.png", Name = "Screenshot"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Effects_16x.png", Name = "Effects"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/PropertyGridEditorPart_16x.png", Name = "PropertyGrid"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Image_16x.png", Name = "ImageSelector"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/CheckboxList_16x.png", Name = "CheckComboBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Ellipsis_16x.png", Name = "PinBox"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Time_color_16x.png", Name = "Clock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/Calendar_16x.png", Name = "CalendarWithClock"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ButtonGroup_16x.png", Name = "ElementGroup"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/layout-FlexLayout-16.png", Name = "FlexPanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/IncreaseHorizontalSpacing_16x.png", Name = "UniformSpacingPanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TransformRelative_16x.png", Name = "RelativePanel"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/TextBlock_16x.png", Name = "Watermark"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/LeftMainContent/ComboBox_16x.png", Name = "AutoCompleteTextBox"},
            };
        }
    }
}
