using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Data;
using HandyControlDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandyControlDemo.ViewModel
{
    public class PaginationViewModel : ViewModelBase
    {
        private readonly List<DemoDataModel> TotalDataList;

        private List<DemoDataModel> dataList;
        public List<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = value;
                RaisePropertyChanged("PageIndex");
            }
        }

        public PaginationViewModel()
        {
            PageIndex = 1;
            TotalDataList = GetDataList(100);
            DataList = TotalDataList.Take(10).ToList();
        }

        public List<DemoDataModel> GetDataList(int count)
        {
            List<DemoDataModel> list = new List<DemoDataModel>();
            for (int i = 1; i <= count; i++)
            {
                int index = i % 6 + 1;
                DemoDataModel model = new DemoDataModel
                {
                    Index = i,
                    IsSelected = i % 2 == 0,
                    Name = $"Name{i}",
                    Type = (DemoType)index,
                    ImgPath = $"pack://application:,,,/Resource/Image/Avatar/avatar{index}.png",
                    Remark = new string(i.ToString()[0], 10)
                };
                list.Add(model);
            }
            return list;
        }

        // 页码改变命令
        public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd =>
            new Lazy<RelayCommand<FunctionEventArgs<int>>>(() =>
                new RelayCommand<FunctionEventArgs<int>>(PageUpdated)).Value;

        // 页码改变
        private void PageUpdated(FunctionEventArgs<int> info)
        {
            DataList = TotalDataList.Skip((info.Info - 1) * 10).Take(10).ToList();
        }
    }
}
