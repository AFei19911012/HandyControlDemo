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
        private ObservableCollection<DemoDataModel> dataList;
        public ObservableCollection<DemoDataModel> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

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
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel{ Name = "Name1", IsSelected = true},
                new DemoDataModel{ Name = "Name2", IsSelected = false},
                new DemoDataModel{ Name = "Name3", IsSelected = true},
            };
        }
    }
}
