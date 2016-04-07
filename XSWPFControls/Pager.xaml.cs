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
        public static DependencyProperty PageCountProperty;
        public static DependencyProperty RecordCountProperty;


        public int PageIndex
        {
            get
            {
                return (int)GetValue(PageIndexProperty);
            }
            set
            {
                SetValue(PageIndexProperty, value);
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

        public int PageCount
        {
            get
            {
                return (int)GetValue(PageCountProperty);
            }
            set
            {
                SetValue(PageCountProperty, value);
            }
        }

        public int RecordCount
        {
            get
            {
                return (int)GetValue(RecordCountProperty);
            }
            set
            {
                SetValue(RecordCountProperty, value);
            }
        }

        #endregion

        #region Event
        public static readonly RoutedEvent PageIndexChangedEvent;
        public event RoutedPropertyChangedEventHandler<int> PageIndexChanged
        {
            add { AddHandler(PageIndexChangedEvent, value); }
            remove { RemoveHandler(PageIndexChangedEvent, value); }
        }

        #endregion
        static Pager()
        {
            PageIndexProperty = DependencyProperty.Register("PageIndex", typeof(int), typeof(Pager), null);
            PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(Pager), null);
            PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(Pager), null);
            RecordCountProperty = DependencyProperty.Register("RecordCount", typeof(int), typeof(Pager), null);

            PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble, 
                typeof(RoutedPropertyChangedEventArgs<int>), typeof(Pager));
        }

    }
}
