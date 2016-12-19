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

namespace WPFControls
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class SimplePager : UserControl, ICommandSource
    {
        public SimplePager()
        {
            InitializeComponent();
        }

        #region 属性

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

        public static readonly DependencyProperty PageIndexProperty =
              DependencyProperty.Register("PageIndex", typeof(int), typeof(SimplePager), new PropertyMetadata(1));


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

        public static readonly DependencyProperty PageSizeProperty =
              DependencyProperty.Register("PageSize", typeof(int), typeof(SimplePager), new PropertyMetadata(20, new PropertyChangedCallback(PageSizePropertyChanged)));

        private static void PageSizePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SimplePager pager = d as SimplePager;
            if (pager != null)
            {
                pager.InitialData();
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

        public static readonly DependencyProperty PageCountProperty =
              DependencyProperty.Register("PageCount", typeof(int), typeof(SimplePager), new PropertyMetadata(1));


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

        public static readonly DependencyProperty RecordCountProperty =
              DependencyProperty.Register("RecordCount", typeof(int), typeof(SimplePager),
                  new PropertyMetadata(0, new PropertyChangedCallback(RecordCountChanged)));

        private static void RecordCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SimplePager pager = d as SimplePager;
            if (pager != null)
            {
                pager.InitialData();
            }
        }

        #endregion


        /// <summary>
        /// 初始化数据
        /// 只有在PageSize和RecordCount的值发生变化的时候进行
        /// </summary>
        private void InitialData()
        {
            //根据RecordCount计算PageCount
            if (RecordCount == 0)
            {
                PageCount = 1;
            }
            else
            {
                PageCount = RecordCount % PageSize > 0 ? (RecordCount / PageSize) + 1 : RecordCount / PageSize;
            }


            //设置核验PageIndex和PageSize的值

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

            SetText();
        }

        #region 设置控件文字和按钮
        private void SetButton()
        {
            this.btnFirst.IsEnabled = CanGoFirstOrPrev();
            this.btnPrev.IsEnabled = CanGoFirstOrPrev();

            this.btnNext.IsEnabled = CanGoNextOrLast();
            this.btnLast.IsEnabled = CanGoNextOrLast();
        }


        private bool CanGoFirstOrPrev()
        {
            return PageIndex > 1;
        }

        private bool CanGoNextOrLast()
        {
            return PageIndex < PageCount;
        }

        private void SetText()
        {
            txtPageInformation.Text = $"{LabelPageIndex}={PageIndex},{LabelPageCount}={PageCount},{LabelRecordCount}={RecordCount},{LabelPageSize}={PageSize}";
            SetButton();
        }
        #endregion

        #region CommandSource部分
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public static readonly DependencyProperty CommandProperty =
              DependencyProperty.Register("Command", typeof(ICommand), typeof(SimplePager), new PropertyMetadata((ICommand)null));



        public object CommandParameter
        {
            get
            {
                return (object)GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        public static readonly DependencyProperty CommandParameterProperty =
              DependencyProperty.Register("CommandParameter", typeof(object), typeof(SimplePager), new PropertyMetadata(null));


        public IInputElement CommandTarget
        {
            get
            {
                return this;
            }
        }

        private void OnCommandExecute()
        {
            if (Command != null)
            {
                SetText();
                Command.Execute(CommandParameter);
            }
        }
        private void OnCommandCanExecute()
        {
            if (Command != null)
            {
                this.IsEnabled = Command.CanExecute(CommandParameter);
            }
        }

        #endregion

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 1;
            OnCommandExecute();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex>0)
            {
                PageIndex--;
            }
            OnCommandExecute();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex<PageCount)
            {
                PageIndex++;
            }
            OnCommandExecute();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = PageCount;
            OnCommandExecute();
        }

        #region 标签属性，用于中英文内容设置

        public string LabelPageIndex
        {
            get
            {
                return (string)GetValue(LabelPageIndexProperty);
            }
            set
            {
                SetValue(LabelPageIndexProperty, value);
            }
        }

        public static readonly DependencyProperty LabelPageIndexProperty =
              DependencyProperty.Register("LabelPageIndex", typeof(string), typeof(SimplePager), new PropertyMetadata("Current Page Index"));

        public string LabelPageCount
        {
            get
            {
                return (string)GetValue(LabelPageCountProperty);
            }
            set
            {
                SetValue(LabelPageCountProperty, value);
            }
        }

        public static readonly DependencyProperty LabelPageCountProperty =
              DependencyProperty.Register("LabelPageCount", typeof(string), typeof(SimplePager), new PropertyMetadata("Total Pages"));


        public string LabelRecordCount
        {
            get
            {
                return (string)GetValue(LabelRecordCountProperty);
            }
            set
            {
                SetValue(LabelRecordCountProperty, value);
            }
        }

        public static readonly DependencyProperty LabelRecordCountProperty =
              DependencyProperty.Register("LabelRecordCount", typeof(string), typeof(SimplePager), new PropertyMetadata("Total Record Count"));


        public string LabelPageSize
        {
            get
            {
                return (string)GetValue(LabelPageSizeProperty);
            }
            set
            {
                SetValue(LabelPageSizeProperty, value);
            }
        }

        public static readonly DependencyProperty LabelPageSizeProperty =
              DependencyProperty.Register("LabelPageSize", typeof(string), typeof(SimplePager), new PropertyMetadata("Page Size"));

        #endregion


    }
}
