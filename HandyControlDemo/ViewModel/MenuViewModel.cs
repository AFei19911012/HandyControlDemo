using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public MenuViewModel()
        {
            DataList = GetDataList();
        }

        private string _tagName;
        public string TagName
        {
            get => _tagName;
            set => Set(ref _tagName, value);
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Header = "Name1", Content = "\ue603" , DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Header = "Name1-1", Content = "\ue604"},
                                                                                                         new DemoDataModel { Header = "Name1-2", Content = "\ue604"},} },
                new DemoDataModel{ Header = "Name2", Content = "\ue603" , DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Header = "Name2-1", Content = "\ue604"},
                                                                                                         new DemoDataModel { Header = "Name2-2", Content = "\ue604"},} },
                new DemoDataModel{ Header = "Name3", Content = "\ue603"},
            };
        }
    }
}
