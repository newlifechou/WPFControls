using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Developer:xs.zhou@outlook.com
    CreateTime:2016/4/8 8:52:13
*/
namespace XSWPFControls
{
    public class SimplePagerViewModel : ViewModelBase
    {
        #region 属性
        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                if (pageIndex == value)
                    return;
                pageIndex = value;
                RaisePropertyChanged(() => PageIndex);
            }
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (pageSize == value)
                    return;
                pageSize = value;
                RaisePropertyChanged(() => PageSize);
                InitData();
            }
        }

        private int recordCount;
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                if (recordCount == value)
                    return;
                recordCount = value;
                RaisePropertyChanged(() => RecordCount);
                InitData();
            }
        }

        private int pageCount;
        public int PageCount
        {
            get { return pageCount; }
            set
            {
                if (pageCount == value)
                    return;
                pageCount = value;
                RaisePropertyChanged(() => PageCount);
            }
        }

        #endregion

        #region 命令
        public RelayCommand<int> FirstCommand { get; set; }
        public RelayCommand<int> PrevCommand { get; set; }
        public RelayCommand<int> NextCommand { get; set; }
        public RelayCommand<int> LastCommand { get; set; }
        #endregion

        public SimplePagerViewModel()
        {
            PageSize = 20;
            FirstCommand = new RelayCommand<int>(ActionFisrt, CanFirst);
            PrevCommand = new RelayCommand<int>(ActionPrev, CanPrev);
            NextCommand = new RelayCommand<int>(ActionNext, CanNext);
            LastCommand = new RelayCommand<int>(ActionLast, CanLast);
        }

        private bool CanLast(int arg)
        {
            return PageIndex < PageCount;
        }

        private void ActionLast(int obj)
        {
            PageIndex =PageCount;
            PageIndexChangedMessage();
        }

        private bool CanNext(int arg)
        {
            return PageIndex < PageCount;
        }

        private void ActionNext(int obj)
        {
            PageIndex += 1;
            PageIndexChangedMessage();
        }

        private bool CanPrev(int arg)
        {
            return PageIndex > 1;
        }

        private void ActionPrev(int obj)
        {
            PageIndex -= 1;
            PageIndexChangedMessage();
        }

        private bool CanFirst(int arg)
        {
            return PageIndex > 1;
        }

        private void ActionFisrt(int obj)
        {
            PageIndex = 1;
            PageIndexChangedMessage();
        }

        /// <summary>
        /// 初始化数据修改
        /// </summary>
        private void InitData()
        {
            //设置外界输入RecordCount和PageSize的时候调用
            //PageCount和PageIndex由内部设定
            //PageIndex从1开始，不是从0
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
        /// 页码改变的时候发送消息
        /// </summary>
        /// <param name="PageIndex"></param>
        public void  PageIndexChangedMessage()
        {
            if (PageIndex < 1)
            {
                PageIndex = 1;
                return;
            }

            if (PageIndex > PageCount)
            {
                PageIndex = PageCount;
                return;
            }

            Messenger.Default.Send<int>(PageIndex, "PageChangedMessenge");
        }






    }
}
