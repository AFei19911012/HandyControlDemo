using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    class ListViewViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public ListViewViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Index = 1, Name = "Name1", Remark = "111111" },
                new DemoDataModel{ Index = 2, Name = "Name2", Remark = "222222" },
                new DemoDataModel{ Index = 3, Name = "Name3", Remark = "333333" },
                new DemoDataModel{ Index = 4, Name = "Name4", Remark = "444444" },
                new DemoDataModel{ Index = 5, Name = "Name5", Remark = "555555" },
                new DemoDataModel{ Index = 6, Name = "Name6", Remark = "666666" },

            };
        }
    }
}
