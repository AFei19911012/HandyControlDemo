﻿using GalaSoft.MvvmLight;
using HandyControlDemo.Model;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class TransferViewModel : ViewModelBase
    {
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public TransferViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel
                {
                    Name = "Name1",
                },
                new DemoDataModel
                {
                    Name = "Name2",
                },
                new DemoDataModel
                {
                    Name = "Name3",
                },
                new DemoDataModel
                {
                    Name = "Name4",
                },
                new DemoDataModel
                {
                    Name = "Name5",
                },
                new DemoDataModel
                {
                    Name = "Name6",
                },
                new DemoDataModel
                {
                    Name = "Name7",
                },
            };
        }
    }
}
