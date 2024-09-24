using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace HandyControlDemo.Model
{
    ///
    /// ----------------------------------------------------------------
    /// Copyright @Taosy.W 2021 All rights reserved
    /// Author      : Taosy.W
    /// Created Time: 2021/7/23 21:23:46
    /// Description :
    /// ------------------------------------------------------
    /// Version      Modified Time         Modified By    Modified Content
    /// V1.0.0.0     2021/7/23 21:23:46    Taosy.W                 
    ///
    public class PropertyGridDemoModel
    {
        [Category("Category1")]
        public string String { get; set; }

        [Category("Category2")]
        public int Integer { get; set; }

        [Category("Category2")]
        public bool Boolean { get; set; }

        [Category("Category1")]
        public Gender Enum { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }

        public ImageSource ImageSource { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
