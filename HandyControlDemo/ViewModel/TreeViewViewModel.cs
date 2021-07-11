using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class TreeViewViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public TreeViewViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Name = "Name1", DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Name = "Name1-1", DataList = null},
                                                                                                       new DemoDataModel { Name = "Name1-2", DataList = null},} },
                new DemoDataModel{ Name = "Name2", DataList = new ObservableCollection<DemoDataModel>{ new DemoDataModel { Name = "Name2-1", DataList = null},
                                                                                                       new DemoDataModel { Name = "Name2-2", DataList = null},} },
                new DemoDataModel{ Name = "Name3", DataList = null},
            };
        }
    }
}
