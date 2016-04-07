using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XSWPFControls
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
        }

        #region Property
        public static DependencyProperty PageIndexProperty;
        public static DependencyProperty PageSizeProperty;
        public static DependencyProperty TotalPageProperty;
        static Pager()
        {
            PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(int), typeof(Pager), null);
            PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(Pager), null);
            TotalPageProperty = DependencyProperty.Register("TotalPage", typeof(int), typeof(Pager), null);



        }

        public int PageIndex
        {
            get
            {
                return (int)GetValue(PageIndexProperty);
            }
            set
            {
                SetValue(PageIndexProperty,value);
            }
        }
        
        public int PageSize
        {
            get
            {
                return (int)GetValue(PageSizeProperty);
            }
            set
            {
                SetValue(PageSizeProperty, value);
            }
        }

        public int TotalPage
        {
            get
            {
                return (int)GetValue(TotalPageProperty);
            }
            set
            {
                SetValue(TotalPageProperty, value);
            }
        }

        #endregion

        #region Event

        #endregion


    }
}
