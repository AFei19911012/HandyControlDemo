using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace HandyControlDemo.Model
{
    public class DemoDataModel : ViewModelBase
    {
        public int Index { get; set; }

        //public string Name { get; set; }
        private string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }


        public bool IsSelected { get; set; }

        public string Remark { get; set; }

        public DemoType Type { get; set; }

        public string ImgPath { get; set; }

        public ObservableCollection<DemoDataModel> DataList { get; set; }

        // Card
        public string Header { get; set; }

        public string Content { get; set; }

        public string Footer { get; set; }

        // Avatar
        public string DisplayName { get; set; }

        public string Link { get; set; }

        public string AvatarUri { get; set; }

    }
}
