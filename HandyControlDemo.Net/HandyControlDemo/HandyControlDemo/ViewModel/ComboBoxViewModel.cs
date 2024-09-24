using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyControlDemo.ViewModel
{
    public class ComboBoxViewModel : ViewModelBase
    {
        private ObservableCollection<string> dataList;
        public ObservableCollection<string> DataList
        {
            get => dataList;
            set => Set(ref dataList, value);
        }

        public ComboBoxViewModel()
        {
            DataList = GetDataList();
        }

        private ObservableCollection<string> GetDataList()
        {
            return new ObservableCollection<string>
            {
                "Text1",
                "Text2",
                "Text3",
                "Text4",
                "Text5",
            };
        }
    }
}
