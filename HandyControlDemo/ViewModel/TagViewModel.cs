using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControl.Properties.Langs;
using HandyControlDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HandyControlDemo.ViewModel
{
    public class TagViewModel : ViewModelBase
    {
        //private ObservableCollection<DemoDataModel> dataList;
        //public ObservableCollection<DemoDataModel> DataList
        //{
        //    get => dataList;
        //    set => Set(ref dataList, value);
        //}
        public ObservableCollection<DemoDataModel> DataList { get; set; }


        private string _tagName;
        public string TagName
        {
            get => _tagName;
            set => Set(ref _tagName, value);
        }

        public RelayCommand AddItemCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(AddItem)).Value;

        private void AddItem()
        {
            if (string.IsNullOrEmpty(TagName))
            {
                Growl.Warning("Empty content.");
                return;
            }

            DataList.Insert(0, new DemoDataModel
            {
                IsSelected = DataList.Count % 2 == 0,
                Name = TagName
            });
            TagName = string.Empty;
        }

        public TagViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<DemoDataModel> GetDataList()
        {
            //return new ObservableCollection<DemoDataModel>
            //{
            //    new DemoDataModel{ Name = "Name1"},
            //    new DemoDataModel{ Name = "Name2"},
            //    new DemoDataModel{ Name = "Name3"},
            //};
            var list = new ObservableCollection<DemoDataModel>();
            for (int i = 0; i < 3; i++)
            {
                var model = new DemoDataModel
                {
                    Name = $"Name{i}"
                };
                list.Add(model);
            }
            return list;
        }

        public ObservableCollection<DemoDataModel> GetDemoDataList(int count)
        {
            var list = new ObservableCollection<DemoDataModel>();
            for (var i = 1; i <= count; i++)
            {
                var index = i % 6 + 1;
                var model = new DemoDataModel
                {
                    Index = i,
                    IsSelected = i % 2 == 0,
                    Name = $"Name{i}",
                    Type = (DemoType)index,
                    ImgPath = $"/HandyControlDemo;component/Resource/Image/Avatar/avatar{index}.png",
                    Remark = new string(i.ToString()[0], 10)
                };
                list.Add(model);
            }

            return list;
        }
    }
}
