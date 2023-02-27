using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControlDemo.Model;
using System;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class SplitButtonViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public SplitButtonViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ ImgPath = "\ue604", Name = "item1", IsSelected = false},
                new DemoDataModel{ ImgPath = "\ue600", Name = "item2", IsSelected = true},
                new DemoDataModel{ ImgPath = "\ue67f", Name = "item3", IsSelected = false},
            };
        }

        public RelayCommand<string> SelectCmd => new Lazy<RelayCommand<string>>(() =>
            new RelayCommand<string>(str => Growl.Info(str, "InfoMessage"))).Value;
    }
}
