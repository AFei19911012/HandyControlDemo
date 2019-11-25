using HandyControlDemo.Model;

namespace HandyControlDemo.ViewModel
{
    public class InteractiveDialogViewModel : NotificationBinding
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                RaisePropertyChanged("Content");
            }
        }

    }
}
