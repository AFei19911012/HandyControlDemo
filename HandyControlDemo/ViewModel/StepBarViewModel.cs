using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControlDemo.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace HandyControlDemo.ViewModel
{
    public class StepBarViewModel : NotificationBinding
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

        public StepBarViewModel()
        {
            DataList = GetStepBarDataList();
        }

        private ObservableCollection<DemoDataModel> GetStepBarDataList()
        {
            return new ObservableCollection<DemoDataModel>
            {
                new DemoDataModel
                {
                    Name = "Step1",
                    Remark = "Register"
                },
                new DemoDataModel
                {
                    Name = "Step2",
                    Remark = "Fill in something"
                },
                new DemoDataModel
                {
                    Name = "Step3",
                    Remark = "Upload file"
                },
                new DemoDataModel
                {
                    Name = "Step4",
                    Remark = "Complete"
                }
            };
        }

        // 下一步
        public RelayCommand<Panel> NextCmd => new Lazy<RelayCommand<Panel>>(() => new RelayCommand<Panel>(Next)).Value;

        // 上一步
        public RelayCommand<Panel> PrevCmd => new Lazy<RelayCommand<Panel>>(() => new RelayCommand<Panel>(Prev)).Value;

        private void Next(Panel panel)
        {
            foreach (var stepBar in panel.Children.OfType<StepBar>())
            {
                stepBar.Next();
            }
        }

        private void Prev(Panel panel)
        {
            foreach (var stepBar in panel.Children.OfType<StepBar>())
            {
                stepBar.Prev();
            }
        }
    }
}
