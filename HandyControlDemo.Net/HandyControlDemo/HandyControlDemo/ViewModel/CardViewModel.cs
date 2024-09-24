using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControlDemo.Model;
using System;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class CardViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public CardViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Header = "Header1", Content = "pack://application:,,,/Resource/Image/Album/1.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header2", Content = "pack://application:,,,/Resource/Image/Album/2.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header3", Content = "pack://application:,,,/Resource/Image/Album/3.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header4", Content = "pack://application:,,,/Resource/Image/Album/4.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header5", Content = "pack://application:,,,/Resource/Image/Album/5.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header6", Content = "pack://application:,,,/Resource/Image/Album/6.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header7", Content = "pack://application:,,,/Resource/Image/Album/7.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header8", Content = "pack://application:,,,/Resource/Image/Album/8.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header9", Content = "pack://application:,,,/Resource/Image/Album/9.jpg", Footer = "information" },
                new DemoDataModel{ Header = "Header10", Content = "pack://application:,,,/Resource/Image/Album/10.jpg", Footer = "information" },
            };
        }

        public RelayCommand AddItemCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() => DataList.Insert(0, new DemoDataModel { Content = $"pack://application:,,,/Resource/Image/Album/{DateTime.Now.Second % 10 + 1}.jpg" }))).Value;

        public RelayCommand RemoveItemCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(() =>
            {
                if (DataList.Count > 0)
                {
                    DataList.RemoveAt(0);
                }
            })).Value;
    }
}
