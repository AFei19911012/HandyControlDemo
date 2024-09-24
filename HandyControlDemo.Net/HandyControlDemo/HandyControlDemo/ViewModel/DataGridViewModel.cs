using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class DataGridViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public DataGridViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Index = 1, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar1.png", Name = "Name1", IsSelected = false, Type = DemoType.Type1, Remark = "111" },
                new DemoDataModel{ Index = 2, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar2.png", Name = "Name2", IsSelected = true, Type = DemoType.Type2, Remark = "222" },
                new DemoDataModel{ Index = 3, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar3.png", Name = "Name3", IsSelected = true, Type = DemoType.Type3, Remark = "333" },
                new DemoDataModel{ Index = 4, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar4.png", Name = "Name4", IsSelected = false, Type = DemoType.Type4, Remark = "444" },
                new DemoDataModel{ Index = 5, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar5.png", Name = "Name5", IsSelected = false, Type = DemoType.Type5, Remark = "555" },
                new DemoDataModel{ Index = 6, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar6.png", Name = "Name6", IsSelected = false, Type = DemoType.Type6, Remark = "666" },
                new DemoDataModel{ Index = 7, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar1.png", Name = "Name7", IsSelected = true, Type = DemoType.Type2, Remark = "777" },
                new DemoDataModel{ Index = 8, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar3.png", Name = "Name8", IsSelected = false, Type = DemoType.Type4, Remark = "888" },
                new DemoDataModel{ Index = 9, ImgPath = "pack://application:,,,/Resource/Image/Avatar/avatar5.png", Name = "Name9", IsSelected = false, Type = DemoType.Type6, Remark = "999" },
            };
        }
    }
}
