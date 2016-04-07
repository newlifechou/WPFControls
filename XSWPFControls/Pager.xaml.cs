using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Pager : UserControl, INotifyPropertyChanged
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
            PageSizeProperty = DependencyProperty.Register("PageSize", typeof(int), typeof(Pager), new PropertyMetadata(20, (s, e) =>
            {
                var dp = s as Pager;
                if (dp!=null)
                {
                    dp.ChangeNavigationBtnState();
                }
            }));
            PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(Pager), new PropertyMetadata(1));
            RecordCountProperty = DependencyProperty.Register("RecordCount", typeof(int), typeof(Pager), new PropertyMetadata(0, (s, e) =>
            {
                var dp = s as Pager;
                if (dp != null)
                {
                    dp.InitData();
                    dp.ChangeNavigationBtnState();
                }
            }));

            PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventArgs<int>), typeof(Pager));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Can
        //是否可以点击首页和上一页
        public bool CanGoFirstPrev
        {
            get
            {
                return PageIndex > 1;
            }
        }
        //是否可以点击最后页和下一页
        public bool CanGoLastOrNext
        {
            get
            {
                return PageIndex < PageCount;
            }
        }
        #region


        #region ClickEvent
        public void btnFirst_Click(object sender, RoutedEventArgs e)
        {

            OnPageIndexChanged(1);
        }
        public void btnPrev_Click(object sender, RoutedEventArgs e)
        {

            OnPageIndexChanged(PageIndex - 1);
        }
        public void btnNext_Click(object sender, RoutedEventArgs e)
        {

            OnPageIndexChanged(PageIndex + 1);
        }
        public void btnLast_Click(object sender, RoutedEventArgs e)
        {

            OnPageIndexChanged(PageCount);
        }
        #endregion





        /// <summary>
        /// 页码改变的时候触发事件
        /// </summary>
        /// <param name="pageIndex"></param>
        private void OnPageIndexChanged(int pageIndex)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (PageIndex > PageCount)
            {
                PageIndex = PageCount;
            }

            int oldPageIndex = PageIndex;
            int newPageIndex = PageIndex;

            RoutedPropertyChangedEventArgs<int> args =
                new RoutedPropertyChangedEventArgs<int>(oldPageIndex, newPageIndex);
            args.RoutedEvent = Pager.PageIndexChangedEvent;
            this.RaiseEvent(args);

        }
        /// <summary>
        /// 初始化数据修改
        /// </summary>
        private void InitData()
        {
            //需要外界输入RecordCount和PageSize
            //PageCount和PageIndex由内部设定
            if (RecordCount == 0)
            {
                PageCount = 1;
            }
            else
            {
                PageCount = RecordCount % PageSize > 0 ? (RecordCount / PageSize) + 1 : RecordCount / PageSize;
            }

            if (PageIndex < 1)
            {
                PageIndex = 1;
            }

            if (PageIndex > PageCount)
            {
                PageIndex = PageCount;
            }

            if (PageSize < 1)
            {
                PageSize = 20;



            }

        }

        /// <summary>
        /// 通知状态修改
        /// </summary>
        private void ChangeNavigationBtnState()
        {
            OnNotifyPropertyChanged(nameof(CanGoFirstPrev));
            OnNotifyPropertyChanged(nameof(CanGoLastOrNext));
        }

    }
}
