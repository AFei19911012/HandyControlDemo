using GalaSoft.MvvmLight;
using HandyControl.Collections;
using HandyControlDemo.Model;
using System.Collections.Generic;

namespace HandyControlDemo.ViewModel
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @CoderMan/CoderMan1012 2023 All rights reserved
    /// Author      : CoderMan/CoderMan1012
    /// Created Time: 2023/2/4 16:48:03
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time              Modified By                               Modified Content
    /// V1.0.0.0     2023/2/4 16:48:03    CoderMan/CoderMan1012                 
    ///
    public class AutoCompleteTextBoxViewModel : ViewModelBase
    {
        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _ = Set(ref _searchText, value);
                // 输入文本更新时修改绑定的数据源
                FilterItems(value);
            }
        }


        public ManualObservableCollection<DemoDataModel> Items { get; set; } = new ManualObservableCollection<DemoDataModel>();


        private List<DemoDataModel> SourceDataList { get; set; }

        public AutoCompleteTextBoxViewModel()
        {
            // 初始化数据源
            SourceDataList = new List<DemoDataModel>();
            for (int i = 1; i <= 10; i++)
            {
                DemoDataModel model = new DemoDataModel
                {
                    Name = $"Name{i}",
                };
                SourceDataList.Add(model);
            }
        }

        private void FilterItems(string key)
        {
            Items.CanNotify = false;
            Items.Clear();
            foreach (DemoDataModel data in SourceDataList)
            {
                if (data.Name.ToLower().Contains(key.ToLower()))
                {
                    Items.Add(data);
                }
            }
            Items.CanNotify = true;
        }
    }
}