using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class CoverViewViewModel : NotificationBinding
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get { return dataList; }
            set
            {
                dataList = value;
                RaisePropertyChanged("DataList");
            }
        }

        public CoverViewViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/1.jpg", Name = "Image1"},
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/2.jpg", Name = "Image2" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/3.jpg", Name = "Image3" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/4.jpg", Name = "Image4" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/5.jpg", Name = "Image5" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/6.jpg", Name = "Image6" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/7.jpg", Name = "Image7" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/8.jpg", Name = "Image8" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/9.jpg", Name = "Image9" },
                new DemoDataModel{ ImgPath = "pack://application:,,,/Resource/Image/Album/10.jpg", Name = "Image10" },
            };
        }
    }
}
